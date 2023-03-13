using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CRM1
{
    public partial class İstatistikler : System.Web.UI.Page
    {
        CRMEntities db = new CRMEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = db.URUNLER.Count().ToString();     //Ürün sayısı
            Label2.Text = db.MUSTERILER.Count().ToString();  //Müşteri sayısı
            Label3.Text = db.SIPARISLER.Sum(x => x.FIYAT).ToString();   // Verilen sipariş tutarı
            Label4.Text = db.KULLANICILAR.Count().ToString();      // Kullanıcı Sayısı
            Label5.Text = (from x in db.URUNLER orderby x.BRM_ADI descending select x.UNAME).FirstOrDefault();   // en fazla stoklu

        }
    }
}