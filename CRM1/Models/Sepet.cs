namespace CRM1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
    using System.Linq;



    [Table("Sepet")]
    public partial class Sepet
    {

        [Key]
        public int SPT_ID { get; set; }
        public int? URN_ID { get; set; }
        public int? MUS_ID { get; set; }
        public decimal? FIYAT { get; set; } 
        public decimal? TOPLAM { get; set; }
        public decimal? MIKTAR { get; set; }
   
        public int? SIPVERILDIMI { get; set; }

    }
    public class kullanicisepeti
    {
        public string kullanici { get; set; }

        private List<Sepet> _SepetListesi = new List<Sepet>();

        public List<Sepet> _sepetdetay  
        {
            get { return _SepetListesi; }
        }


        public void SepetEkle(Sepet eklenenurun)
        {
            var sepetim = _SepetListesi.Where(x => x.SPT_ID == eklenenurun.SPT_ID && x.URN_ID == eklenenurun.URN_ID).FirstOrDefault();
            if (sepetim==null)
            {
                _SepetListesi.Add(new Sepet() {

                    URN_ID= eklenenurun.URN_ID,
                    MUS_ID = eklenenurun.MUS_ID,
                    MIKTAR = eklenenurun.MIKTAR,
                    FIYAT = eklenenurun.MIKTAR * (eklenenurun.FIYAT)
 
                });

            }
            else
            {
                sepetim.MIKTAR += eklenenurun.MIKTAR;
                sepetim.FIYAT += (eklenenurun.MIKTAR * eklenenurun.FIYAT);
            }

        }

        public void sil(Sepet silinecekurun)
        {
            _SepetListesi.RemoveAll(x => x.SPT_ID == silinecekurun.SPT_ID&& x.URN_ID == silinecekurun.URN_ID);
        }



        public void guncelle(Sepet guncellenecekurun, int guncelmiktar)
        {
            var urun = _SepetListesi.Where(x => x.URN_ID== guncellenecekurun.URN_ID).FirstOrDefault();
            urun.MIKTAR = guncelmiktar;
        }


        public decimal ToplamTutar()
        {
            return (decimal)_SepetListesi.Sum(x => x.MIKTAR * x.FIYAT);
        }


        public decimal kdv()
        {
            return (decimal)_SepetListesi.Sum(x => x.MIKTAR * x.FIYAT) * 0.18m;
        }

        public decimal araToplam()
        {
            return (decimal)_SepetListesi.Sum(x => x.MIKTAR * x.FIYAT) - kdv();
        }


        public void Temizle()
        {
            _SepetListesi.Clear();
        }

        public int sepetsayisi()
        {
            return _SepetListesi.Count();
        }

    }
}
