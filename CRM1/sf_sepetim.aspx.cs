using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM1
{
    public partial class sepetim : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                listele();

                using (var ctx = new CRMEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    
                }
            }
        }
        public void listele()
        {
            using (var ctx = new CRMEntities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                //var urunler = ctx.URUNLER.ToList();

                var liste = (from s in ctx.Sepet
                             join u in ctx.URUNLER on s.URN_ID equals u.URN_ID
                             select new {
                                 s.MIKTAR,
                                 s.SPT_ID,
                                 s.URN_ID,
                                 u.FIYAT,
                                 u.UNAME,
                                 u.FPATH,
                                 s.TOPLAM
                                 
                             }
                             ).ToList();
                var toplam = 0m;
                for (int i = 0; i < liste.Count; i++)
                {
                    toplam += (decimal)liste[i].TOPLAM;
                }
              

                lbl_toplam.Text = toplam.ToString("N2");

                rpt_sepetim.DataSource = liste;
                rpt_sepetim.DataBind();
                

            }
        }
        protected void rpt_Urunler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                using (var ctx = new CRMEntities())
                {
                    int ID = Convert.ToInt32(e.CommandArgument.ToString());
                    ctx.Configuration.LazyLoadingEnabled = false;
                    var obj = new Sepet { SPT_ID = ID };
                    ctx.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();
                    listele();
                    ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('Silindi')</script>");
                    return;
                }
            }
        }
        public string SipNoUret(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public void siparisver(object sender, EventArgs e)
        {
            using (var ctx = new CRMEntities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                
                var sepetler = ctx.Sepet.Where(x => x.SIPVERILDIMI == 0).ToList();
                for (int i = 0; i < sepetler.Count; i++)
                {
                    SIPARISLER s = new SIPARISLER();
                    s.BIRIM = "ADET";
                    s.MIKTAR = sepetler[i].MIKTAR;
                    s.MUS_ID = sepetler[i].MUS_ID;
                    s.FIYAT = sepetler[i].FIYAT;
                    s.TOPLAM = sepetler[i].MIKTAR * sepetler[i].FIYAT;
                    s.URN_ID = sepetler[i].URN_ID;
                    s.SIP_NO = SipNoUret(5);
                    ctx.SIPARISLER.Add(s);
                    ctx.SaveChanges();
                    listele();
                }

                }
        }
        protected void LinkButton_alisveris(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }  
    }
}