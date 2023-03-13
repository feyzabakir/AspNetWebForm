using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;

namespace CRM1
{
    public partial class SifremiUnuttum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        CRMEntities db = new CRMEntities();
        protected void btn_yenile_Click(object sender, EventArgs e)
        {
            var model = db.KULLANICILAR.FirstOrDefault(x => x.EMAIL == TxtEmail.Text);
            if (model!=null)
            {
                Guid guid = Guid.NewGuid();                 //rastgele sayı harf üretmeye yarar
                model.PASSW = guid.ToString().Substring(0, 8);  // 8 karakter alacağız
                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential("testt072021@gmail.com", "test01234");
                client.Port = 587;
                client.Host="smtp.gmail.com";
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.To.Add(TxtEmail.Text);
                mail.From = new MailAddress("testt072021@gmail.com", "Şifre Yenileme");
                mail.IsBodyHtml = true;     // <br/> tanısın diye true dedik
                mail.Subject="Şifre Sıfırlama";
                mail.Body += "Merhaba" + " " + model.NAME + "<br/> Kullanıcı Adı: " + model.USERN + "<br/> Şifre: " + model.PASSW;

                try
                {
                    client.Send(mail);
                    db.SaveChanges();
                    Response.Redirect("Login.aspx");
                   
                }
                catch (Exception)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('HATA')</script>");
                    throw;

                }
            }
        }
    }
}
