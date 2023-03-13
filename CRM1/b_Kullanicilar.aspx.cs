using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Entity;

namespace CRM1
{
    public partial class b_Kullanicilar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }
        public void getir()
        {
            using (var ctx = new CRMEntities())
            {
                try
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //veritabanından gelen liste
                    var kull_list = ctx.KULLANICILAR.ToList();

                    rpt_kull.DataSource = kull_list;
                    rpt_kull.DataBind();
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('HATA')</script>");
                    throw;
                }

            }

        }

        protected void btn_kaydet_Click(object sender, EventArgs e)
        {
           
            if (btn_kaydet.Text.StartsWith("K"))                                                          // kaydetme
            {
                using (var ctx = new CRMEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    try
                    {
                        KULLANICILAR k = new KULLANICILAR();
                        k.CDATE = DateTime.Now;
                        k.CSM = txt_GSM.Text;
                        k.EMAIL = txt_Email.Text;
                        k.NAME = txt_name.Text;
                        k.USERN = txt_Usern.Text;
                        k.PASSW = txt_Passw.Text;
                        ctx.KULLANICILAR.Add(k);
                        ctx.SaveChanges();
                        getir();
                        ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('Kaydedildi')</script>");
                        return;
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('HATA')</script>");
                        throw;
                    }


                }
            }
            if (btn_kaydet.Text.StartsWith("G"))                                                     // güncelleme
            {
                using (var ctx = new CRMEntities())
                {
                    try
                    {
                        ctx.Configuration.LazyLoadingEnabled = false;
                        int id = Convert.ToInt32(btn_kaydet.Attributes["KUL_ID"]);
                        KULLANICILAR k = new KULLANICILAR();
                        k.CDATE = DateTime.Now;
                        k.CSM = txt_GSM.Text;
                        k.EMAIL = txt_Email.Text;
                        k.NAME = txt_name.Text;
                        k.USERN = txt_Usern.Text;
                        k.PASSW = txt_Passw.Text;
                        k.KUL_ID = id;
                        var entry = ctx.Entry(k);
                        entry.State = EntityState.Modified;
                        ctx.SaveChanges();
                        btn_kaydet.Text = "Kaydet";
                        btn_kaydet.Attributes.Remove("KUL_ID");
                        ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('Güncellendi')</script>");
                        getir();
                    }  
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('HATA')</script>");
                        throw;
                    }

                }
            }
            CleartextBoxes(this);

        }

        public void CleartextBoxes(Control parent)
        {
            foreach (Control x in parent.Controls)
            {
                if ((x.GetType() == typeof(TextBox)))
                {
                    ((TextBox)(x)).Text = "";
                }
                if (x.HasControls())
                {
                    CleartextBoxes(x);
                }
            }
        }

        protected void btn_bul_Click(object sender, EventArgs e)
        {
            //Kullanıcıları veri tabanından alma
            getir();

        }

        protected void rpt_kull_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")                                                                      // silme
            {
                using (var ctx = new CRMEntities())
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    var obj = new KULLANICILAR { KUL_ID = id };
                    ctx.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();
                    getir();
                    ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('Kayıt Silindi')</script>");
                    return;
                }
            }
            if (e.CommandName == "dzn")                                                                      // güncellenecek verileri TextBox'a taşıma
            {
                int kul_id = Convert.ToInt32(e.CommandArgument.ToString());
                using (var ctx = new CRMEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    KULLANICILAR kul = ctx.KULLANICILAR.Where(x => x.KUL_ID == kul_id).FirstOrDefault();
                    if (kul != null)
                    {
                        txt_Email.Text = kul.EMAIL;
                        txt_GSM.Text = kul.CSM;
                        txt_name.Text = kul.NAME;
                        txt_Passw.Text = kul.PASSW;
                        txt_Usern.Text = kul.USERN;
                        btn_kaydet.Attributes["KUL_ID"] = kul.KUL_ID.ToString();
                        btn_kaydet.Text = "Güncelle";
                    }
                }
            }
        }
       

    }
}