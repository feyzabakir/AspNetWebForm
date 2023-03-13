using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace CRM1
{
    public partial class b_Musteriler : System.Web.UI.Page
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
                        var musteri_list = ctx.MUSTERILER.ToList();

                        rpt_musteri.DataSource = musteri_list;
                        rpt_musteri.DataBind();
                    }
                    catch (Exception ex)
                    {
                    ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('HATA')</script>");
                    throw;
                    }

                }

            }
        protected void btn_bul_Click(object sender, EventArgs e)                    // listele butonu
        {
            //Kullanıcıları veri tabanından alma
            getir();
        }


        protected void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (btn_kaydet.Text.StartsWith("K"))                          // kaydetme işlemi 
            {
                using (var ctx = new CRMEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    try
                    {
                        MUSTERILER m = new MUSTERILER();
                        m.CDate = DateTime.Now;
                        m.Unvan = txt_Unvan.Text;
                        m.Email = txt_Email.Text;
                        m.SabitTel = txt_Sabittel.Text;
                        m.Adres = txt_Adres.Text;
                        ctx.MUSTERILER.Add(m);
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


            if (btn_kaydet.Text.StartsWith("G"))                                        //Güncelleme işlemi
            {
                using (var ctx = new CRMEntities())
                {
                    try
                    {
                        ctx.Configuration.LazyLoadingEnabled = false;
                        int id = Convert.ToInt32(btn_kaydet.Attributes["CUS_ID"]);
                        MUSTERILER m = new MUSTERILER();
                        m.CDate = DateTime.Now;
                        m.Unvan = txt_Unvan.Text;
                        m.Email = txt_Email.Text;
                        m.SabitTel = txt_Sabittel.Text;
                        m.Adres = txt_Adres.Text;
                        m.CUS_ID = id;
                        var entry = ctx.Entry(m);
                        entry.State = EntityState.Modified;
                        ctx.SaveChanges();
                        btn_kaydet.Text = "Kaydet";
                        btn_kaydet.Attributes.Remove("CUS_ID");
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


      

        protected void rpt_musteriler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")                                                      // silme işlemi
            {
                using (var ctx = new CRMEntities())
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    var obj = new MUSTERILER { CUS_ID = id };
                    ctx.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();
                    getir();
                    ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('Kayıt Silindi')</script>");
                    return;
                }
            }
            if (e.CommandName == "dzn")                                  // güncellenecek kişinin bilgilerini kutucuklara taşıma
            {
                int cus_id = Convert.ToInt32(e.CommandArgument.ToString());
                using (var ctx = new CRMEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    MUSTERILER mus = ctx.MUSTERILER.Where(x => x.CUS_ID == cus_id).FirstOrDefault();
                    if (mus != null)
                    {
                        txt_Email.Text = mus.Email;
                        txt_Unvan.Text = mus.Unvan;
                        txt_Sabittel.Text = mus.SabitTel;
                        txt_Adres.Text = mus.Adres;
                       
                        btn_kaydet.Attributes["CUS_ID"] = mus.CUS_ID.ToString();
                        btn_kaydet.Text = "Güncelle";
                    }
                }
            }

        }

    }
}