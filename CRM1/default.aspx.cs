using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM1
{
    public partial class _default : System.Web.UI.Page
    {
        

        public object Varyant { get; internal set; }
        public object SPT_ID { get; internal set; }
        public object URN_ID { get; internal set; }
        public int MIKTAR { get; internal set; }
        public object MUS_ID { get; internal set; }
        public int FIYAT { get; internal set; }

        public static int sayac = 0;

        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                listele();

                using (var ctx = new CRMEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    var i = ctx.Sepet.Where(x => x.SIPVERILDIMI == 0).ToList().Count();
                    ((Label)((etiaret)this.Master).FindControl("lbl_Sepet_urun_Adedi")).Text = i.ToString();
                }
            }

           
        }

        public void listele()
        {
            using (var ctx = new CRMEntities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                var urunler = ctx.URUNLER.ToList();
                rpt_Urunler.DataSource = urunler;
                rpt_Urunler.DataBind();

            }
        }

        protected void rpt_Urunler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ekle")
            {
                using (var ctx = new CRMEntities())
                {
                    int Urun_ID = Convert.ToInt32(e.CommandArgument.ToString());
                    ctx.Configuration.LazyLoadingEnabled = false;
                    var urun = ctx.URUNLER.Where(x => x.URN_ID == Urun_ID).FirstOrDefault();

                    Sepet s = new Sepet();
                    s.FIYAT = urun.FIYAT;
                    s.URN_ID = urun.URN_ID;
                    s.MIKTAR = 1;
                    s.MUS_ID = 1;
                    s.SIPVERILDIMI = 0;
                    s.TOPLAM = s.FIYAT * s.MIKTAR;
                    ctx.Sepet.Add(s);
                    ctx.SaveChanges();
                    ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('Sepete Eklendi')</script>");
                }
            }
        }

       

       


    }

}

   

  
   

  