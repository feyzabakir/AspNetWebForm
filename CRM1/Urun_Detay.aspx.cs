using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace CRM1
{
    public partial class Urun_Detay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id = Request.QueryString["URN_ID"];
            if (string.IsNullOrEmpty(Id) == false)
            {
                listele(Id);
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
        public void listele(string Id)
        {
            int id = int.Parse(Id);
            using (var ctx = new CRMEntities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                //  var liste = ctx.URUNLER.ToList();

                var liste = (from i in ctx.URUNLER
                              where i.URN_ID == id
                              select new {
                                  i.UNAME,
                                  i.FIYAT,
                                  i.CODE,
                                  i.BRM_ADI,
                                  i.FPATH,
                                  i.URN_ID

                              }).ToList();

                Repeater1.DataSource = liste;
                Repeater1.DataBind();
            }
        }
    }
}
