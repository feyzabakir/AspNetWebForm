using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRM1
{
    public partial class anasayfa : System.Web.UI.Page
    {
        public static int sayac = 0;

        public void sld()
        {
            if(sayac == 1)
            {
                Label1.Text = " <img src='resimler/slider1.jpg' width='900px' height='500px' /> ";
            }
            else if(sayac == 2)
            {
                Label1.Text = " <img src='resimler/slider2.jpg' width='900px' height='500px' /> ";
            }
            else if (sayac == 3)
            {
                Label1.Text = " <img src='resimler/slider3.jpg' width='900px' height='500px' /> ";
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            sayac++;
            if (sayac == 4)
            {
                sayac = 1;
            }
            sld();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //ileri
            sayac++;
            if(sayac == 4)
            {
                sayac = 1;
            }
            sld();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //geri
            sayac--;
            if(sayac == -1)
            {
                sayac = 1;
            }
            sld();
        }
    }
}