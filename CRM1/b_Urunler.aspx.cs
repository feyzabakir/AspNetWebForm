using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.IO;

namespace CRM1
{
    public partial class b_Urunler : System.Web.UI.Page
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
                    var urun_list = ctx.URUNLER.ToList();

                    rpt_urunler.DataSource = urun_list;
                    rpt_urunler.DataBind();
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
            if (btn_kaydet.Text.StartsWith("K"))                                // kaydetme
            {
                using (var ctx = new CRMEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    try
                    {
                        URUNLER u = new URUNLER();
                        u.UNAME = txt_Uname.Text;
                        u.CODE = txt_Code.Text;
                        decimal dec = 0m;
                        decimal.TryParse(txt_Fiyat.Text, out dec);
                        u.FIYAT = dec;
                        u.BRM_ADI = txt_Brm_adi.Text;
                        u.CDATE = DateTime.Now;

                        string fpath = null;
                        if (FU_File.HasFile)
                        {
                            FileInfo dosyaBilgisi = new FileInfo(FU_File.FileName);
                            fpath = Guid.NewGuid().ToString() + dosyaBilgisi.Extension;
                            FU_File.SaveAs(Server.MapPath("/resimler/") + fpath);
                            u.FPATH = fpath;
                        }

                        ctx.URUNLER.Add(u);
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
            if (btn_kaydet.Text.StartsWith("G"))                         // güncelleme
            {
                using (var ctx = new CRMEntities())
                {
                    try
                    {
                        ctx.Configuration.LazyLoadingEnabled = false;
                        int id = Convert.ToInt32(btn_kaydet.Attributes["URN_ID"]);
                        URUNLER u = new URUNLER();
                        u.CDATE = DateTime.Now;
                        u.UNAME = txt_Uname.Text;
                        u.CODE = txt_Code.Text;
                        decimal dec = 0m;
                        decimal.TryParse(txt_Fiyat.Text, out dec);
                        u.FIYAT = dec;
                        u.BRM_ADI = txt_Brm_adi.Text; 
                        u.URN_ID = id;
                        string fpath = null;
                        if (FU_File.HasFile)
                        {
                            FileInfo dosyaBilgisi = new FileInfo(FU_File.FileName);
                            fpath = Guid.NewGuid().ToString() + dosyaBilgisi.Extension;
                            FU_File.SaveAs(Server.MapPath("/resimler/") + fpath);
                            u.FPATH = fpath;
                        }
                        var entry = ctx.Entry(u);
                        entry.State = EntityState.Modified;
                        ctx.SaveChanges();
                        btn_kaydet.Text = "Kaydet";
                        btn_kaydet.Attributes.Remove("URN_ID");
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

        protected void rpt_urunler_ItemCommand(object source, RepeaterCommandEventArgs e)
        { 
            if (e.CommandName == "Sil")                                         // silme
            {
                using (var ctx = new CRMEntities())
                {
                    int id = Convert.ToInt32(e.CommandArgument.ToString());
                    var obj = new URUNLER { URN_ID = id };
                    ctx.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();
                    getir();
                    ClientScript.RegisterStartupScript(GetType(), "Yeni", "<script>alert('Kayıt Silindi')</script>");
                    return;
                }
            }

            if (e.CommandName == "dzn")                                             // güncellenecek veriyi TextBox'a taşıma
            {
                int urn_id = Convert.ToInt32(e.CommandArgument.ToString());
                using (var ctx = new CRMEntities())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    URUNLER urn = ctx.URUNLER.Where(x => x.URN_ID == urn_id).FirstOrDefault();
                    if (urn != null)
                    {
                       txt_Uname.Text = urn.UNAME;
                        txt_Brm_adi.Text = urn.BRM_ADI;
                        txt_Code.Text = urn.CODE;
                        decimal dec = 0m;
                        decimal.TryParse(txt_Fiyat.Text, out dec);
                        urn.FIYAT = dec;
                        btn_kaydet.Attributes["URN_ID"] = urn.URN_ID.ToString();
                        btn_kaydet.Text = "Güncelle";


                    }
                }
            }

        }


    }
}