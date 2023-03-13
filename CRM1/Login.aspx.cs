using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM1
{
    public partial class Login2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void login(object sender, EventArgs e)
        {

            using (CRMEntities ctx = new CRMEntities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                var users = ctx.KULLANICILAR.Where(x => x.USERN == txt_kullaniciadi.Text && x.PASSW == txt_sifre.Text).FirstOrDefault();
                if (users != null)
                {
                    Response.Redirect("anasayfa.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('Kullanıcı adı veya şifre yanlış! ')</script>");
                    return;
                }

            }
        }
    }
}