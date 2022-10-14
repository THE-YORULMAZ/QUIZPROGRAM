using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QUIZPROGRAM
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=THEYORULMAZZ;Initial Catalog=QUIZPROGRAM;Integrated Security=True");
        DataTable tablo = new DataTable();

        int puanalfa = 0;
        int puanbeta = 0;
        int puanmeta = 0;
        int puansigma = 0;
        int puanomega = 0;
        int puangamma = 0;

        void LİSTELEME()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from grup where SORU= '" + label7.Text + "'", baglanti);
            SqlDataReader OKUYUCU = komut.ExecuteReader();
            while (OKUYUCU.Read())
            {
                txtalfa.Text = OKUYUCU["ALFA"].ToString();
                txtbeta.Text = OKUYUCU["BETA"].ToString();
                txtmeta.Text = OKUYUCU["META"].ToString();
                txtsigma.Text = OKUYUCU["SİGMA"].ToString();
                txtomega.Text = OKUYUCU["OMEGA"].ToString();
                txtgamma.Text = OKUYUCU["GAMMA"].ToString();
            }
            baglanti.Close();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            LİSTELEME();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (puanalfa==0 && puanalfa==00)
            {
                txtalfa.Text = "00";
            }
            else
            {
                puanalfa = puanalfa - 10;
                txtalfa.Text = puanalfa.ToString();
            }
        }

        private void btnalfarttır_Click(object sender, EventArgs e)
        {
            puanalfa = puanalfa + 10;
            txtalfa.Text = puanalfa.ToString();
        }

        private void btnbetarttır_Click(object sender, EventArgs e)
        {
            puanbeta = puanbeta + 10;
            txtbeta.Text = puanbeta.ToString();
        }

        private void btnbetazalt_Click(object sender, EventArgs e)
        {
            if (puanbeta == 0 && puanbeta == 00)
            {
                txtbeta.Text = "00";
            }
            else
            {
                puanbeta = puanbeta - 10;
                txtbeta.Text = puanbeta.ToString();
            }
        }

        private void btnmetarttır_Click(object sender, EventArgs e)
        {
            puanmeta = puanmeta + 10;
            txtmeta.Text = puanmeta.ToString();
        }

        private void btnmetazalt_Click(object sender, EventArgs e)
        {

            if (puanmeta == 0 && puanmeta == 00)
            {
                txtmeta.Text = "00";
            }
            else
            {
                puanmeta = puanmeta - 10;
                txtmeta.Text = puanmeta.ToString();
            }
        }

        private void btnsigmazalt_Click(object sender, EventArgs e)
        {
            if (puansigma == 0 && puansigma == 00)
            {
                txtsigma.Text = "00";
            }
            else
            {
                puansigma = puansigma - 10;
                txtsigma.Text = puansigma.ToString();
            }
            
        }

        private void btnsigmarttır_Click(object sender, EventArgs e)
        {
            puansigma = puansigma + 10;
            txtsigma.Text = puansigma.ToString();
        }

        private void btnomegarttır_Click(object sender, EventArgs e)
        {
            puanomega = puanomega + 10;
            txtomega.Text = puanomega.ToString();
        }

        private void btnomegazalt_Click(object sender, EventArgs e)
        {
            if (puanomega == 0 && puanomega == 00)
            {
                txtomega.Text = "00";
            }
            else
            {
                puanomega = puanomega - 10;
                txtomega.Text = puanomega.ToString();
            }
        }

        private void btngamarttır_Click(object sender, EventArgs e)
        {
            puangamma = puangamma + 10;
            txtgamma.Text = puangamma.ToString();
        }

        private void btngamazalt_Click(object sender, EventArgs e)
        {
            if (puangamma == 0 && puangamma == 00)
            {
                txtgamma.Text = "00";
            }
            else
            {
                puangamma = puangamma - 10;
                txtgamma.Text = puangamma.ToString();
            }
        }

        private void btnkydt_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = baglanti;
            cmd4.CommandText= "UPDATE grup SET ALFA='" +txtalfa.Text+ "',BETA='" +txtbeta.Text+ "',META='" + txtmeta.Text + "',SİGMA='" + txtsigma.Text + "',OMEGA='" + txtomega.Text + "',GAMMA='" + txtgamma.Text + "' where SORU=@num";
            cmd4.Parameters.AddWithValue("@num", label7.Text.ToString());
            cmd4.ExecuteNonQuery();
            cmd4.Dispose();
            baglanti.Close();
            this.Hide();
        }
    }
}
