using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listele();
            }
        }
        public void Listele()
        {
            using (var ctx = new CRMEntities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                var liste = (from v in ctx.SIPARISLER
                             join u in ctx.URUNLER on v.URN_ID equals u.URN_ID

                             select new {
                                 v.MIKTAR,
                                 v.FIYAT,
                                 v.MUS_ID,
                                 v.TOPLAM,
                                 v.SIP_NO,
                                 v.BIRIM,
                                 u.UNAME,
                             }).ToList();
                var toplam = 0m;
                for (int i = 0; i < liste.Count; i++)
                {
                    toplam += (decimal)liste[i].TOPLAM;
                }
                rpt_sipler.DataSource = liste;
                rpt_sipler.DataBind();

                lbl_toplam.Text = toplam.ToString("N2");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}