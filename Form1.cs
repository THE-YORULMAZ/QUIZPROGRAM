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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=THEYORULMAZZ;Initial Catalog=QUIZPROGRAM;Integrated Security=True");
        DataTable tablo = new DataTable();

        void sayac()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from sorular", baglanti);
            SqlDataReader okuyucu1 = cmd.ExecuteReader();
            while (okuyucu1.Read())
            {
                lbltplsoru.Text = okuyucu1[0].ToString();
            }
            baglanti.Close();
        }
        void renk()
        {
            btna.BackColor = Color.Gainsboro;
            btnb.BackColor = Color.Gainsboro;
            btnc.BackColor = Color.Gainsboro;
            btnd.BackColor = Color.Gainsboro;
        }

        int sayi;
        int dogru = 0;
        int yanlis = 0;
        int puan = 0;

        private void btnplay_Click(object sender, EventArgs e)
        {
            btnplay.Enabled = false;
            renk();
            sayi = sayi + 1;
            lblsoru.Text = sayi.ToString();
            btna.Visible = false;
            btnb.Visible = false;
            btnc.Visible = false;
            btnd.Visible = false;
            btnsurebasla.Enabled = true;
            btnsuredur.Enabled = true;
            btnsureek.Enabled = true;
            btndevam.Enabled = true;
            eliijokerimenu.Enabled = false;
            syrcmenu.Enabled = false;
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from sorular where SORUNUNSAYISI='" + lblsoru.Text + "'", baglanti);
            SqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                rtxtsoru.Text = (okuyucu["SORU"].ToString());
                btna.Text = (okuyucu["A"].ToString());
                btnb.Text = (okuyucu["B"].ToString());
                btnc.Text = (okuyucu["C"].ToString());
                btnd.Text = (okuyucu["D"].ToString());
                lbldogrucevapgoster.Text = (okuyucu["DOGRU"].ToString());
                lblkonu.Text = (okuyucu["KONUSU"].ToString());
                lblsinif.Text = okuyucu["SINIF"].ToString();
            }
            baglanti.Close();
            btnplay.Text = "SONRAKİ SORU";
            btnplay.Enabled = false;
            if (rtxtsoru.Text == "")
            {
                MessageBox.Show("SORU BOŞ OLARAK GELMİŞTİR.SORULAR PANELİNDEN SORU SIRALAMASINI AYARLAYABİLİRSİNİZ.");
            }
            if (lblsoru.Text == lbltplsoru.Text)
            {
                sayi = 0;
                MessageBox.Show("YARIŞMAMIZ BİTMİŞTİR");
                btnplay.Text = "YARIŞMAYA BAŞLA";
                btnplay.Enabled = true;
                btna.Enabled = false;
                btnb.Enabled = false;
                btnc.Enabled = false;
                btnd.Enabled = false;
                lblsoru.Text = "00";
                sonuc();
            }
            if (sayi == 1)
            {
                if (MessageBox.Show("OYUN GRUBLAR HALİNDE Mİ OYNANACAK ?","SİSTEM",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk)==DialogResult.Yes)
                {
                    panel10.Visible = true;
                }
                else
                {
                    panel10.Visible = false;
                }
                dogru = 0;
                yanlis = 0;
                puan = 0;
                hak = 0;
                hak2 = 0;
                lblelli.Text= "00";
                lblseyirci.Text= "00";
                lbldogrusayi.Text = "00";
                lblyanlissayi.Text = "00";
                lblpuan.Text = "00";
            }

        }

        private void btna_Click(object sender, EventArgs e)
        {
            if (lblsoru.Text=="00")
            {
                MessageBox.Show("YARIŞMAYA BAŞLA BUTONUNA TIKLAYINIZ");
            }
            else
            {
                btnb.Enabled = false;
                btnc.Enabled = false;
                btnd.Enabled = false;
                btnplay.Enabled = true;
                timer1.Enabled = false;
                timer2.Enabled = false;
                if (lbldogrucevapgoster.Text == btna.Text)
                {
                    dogru++;
                    lbldogrusayi.Text = dogru.ToString();
                    btna.BackColor = Color.Lime;

                    puan = puan + 10;
                    lblpuan.Text = puan.ToString();
                }
                else
                {
                    yanlis++;
                    lblyanlissayi.Text = yanlis.ToString();
                    btna.BackColor = Color.Red;

                }
            }
            
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (lblsoru.Text=="00")
            {
                form2 frm = new form2();
                frm.Show();
            }
            else
            {
                MessageBox.Show("YARIŞMA HALİNDE SORU İŞLEMLERİ YAPAMAZSINIZ.YARIŞMAYI BİTİRİNİZ!!!");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sayac();
            rtxtsoru.Enabled = false;
            ayarlar();
        }

        private void btnb_Click(object sender, EventArgs e)
        {
            if (lblsoru.Text == "00")
            {
                MessageBox.Show("YARIŞMAYA BAŞLA BUTONUNA TIKLAYINIZ");
            }
            else
            {
                btna.Enabled = false;
                btnc.Enabled = false;
                btnd.Enabled = false;
                btnplay.Enabled = true;
                timer1.Enabled = false;
                timer2.Enabled = false;
                if (lbldogrucevapgoster.Text == btnb.Text)
                {
                    dogru++;
                    lbldogrusayi.Text = dogru.ToString();
                    btnb.BackColor = Color.Lime;

                    puan = puan + 10;
                    lblpuan.Text = puan.ToString();
                }
                else
                {
                    yanlis++;
                    lblyanlissayi.Text = yanlis.ToString();
                    btnb.BackColor = Color.Red;

                }
            }
            
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            if (lblsoru.Text == "00")
            {
                MessageBox.Show("YARIŞMAYA BAŞLA BUTONUNA TIKLAYINIZ");
            }
            else
            {
                btnb.Enabled = false;
                btna.Enabled = false;
                btnd.Enabled = false;
                btnplay.Enabled = true;
                timer1.Enabled = false;
                timer2.Enabled = false;
                if (lbldogrucevapgoster.Text == btnc.Text)
                {
                    dogru++;
                    lbldogrusayi.Text = dogru.ToString();
                    btnc.BackColor = Color.Lime;

                    puan = puan + 10;
                    lblpuan.Text = puan.ToString();
                }
                else
                {
                    yanlis++;
                    lblyanlissayi.Text = yanlis.ToString();
                    btnc.BackColor = Color.Red;

                }
            }
               
        }

        private void btnd_Click(object sender, EventArgs e)
        {
            if (lblsoru.Text == "00")
            {
                MessageBox.Show("YARIŞMAYA BAŞLA BUTONUNA TIKLAYINIZ");
            }
            else
            {
                btnb.Enabled = false;
                btnc.Enabled = false;
                btna.Enabled = false;
                btnplay.Enabled = true;
                timer1.Enabled = false;
                timer2.Enabled = false;
                if (lbldogrucevapgoster.Text == btnd.Text)
                {
                    dogru++;
                    lbldogrusayi.Text = dogru.ToString();
                    btnd.BackColor = Color.Lime;

                    puan = puan + 10;
                    lblpuan.Text = puan.ToString();
                }
                else
                {
                    yanlis++;
                    lblyanlissayi.Text = yanlis.ToString();
                    btnd.BackColor = Color.Red;

                }
            }
           
        }
        int sure1 = 30;
        private void btnsurebasla_Click(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            sure1 = 30;
            lbltimer.Text = sure1.ToString();
            timer1.Enabled = true;
            btnsurebasla.Enabled = false;
            btncevab.Enabled = false;
            btnsureek.Enabled = false;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sure1 = Convert.ToInt32(lbltimer.Text);
            sure1 = sure1 - 1;
            lbltimer.Text = sure1.ToString();
            
            if(sure1==0)
            {
                
                timer1.Enabled = false;
                btncevab.Enabled = true;
                btna.Enabled = false;
                btnb.Enabled = false;
                btnc.Enabled = false;
                btnd.Enabled = false;
                btnsureek.Enabled = true;
                btnsuredur.Enabled = false;
                btndevam.Enabled = false;
                eliijokerimenu.Enabled = true;
                syrcmenu.Enabled = false;
                panel6.Visible = false;
            }
        }

        private void btnsuredur_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void btndevam_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btncevab_Click(object sender, EventArgs e)
        {
            if (lbltimer.Text=="00")
            {
                MessageBox.Show("YARIŞMA BAŞLA BUTONUNA TIKLAYIP YARIŞMAYA BAŞLAYIN");
            }
            else
            {
                MessageBox.Show("SORUNUN CEVABI " + lbldogrucevapgoster.Text + "","SİSTEM",MessageBoxButtons.OK,MessageBoxIcon.Information); ;
                btnplay.Enabled = true;
                
            }
        }
        int sure2 = 20;
        private void btnsureek_Click(object sender, EventArgs e)
        {
            sure2 = 20;
            lblekstra.Text = sure2.ToString();
            timer2.Enabled = true;
            btnsurebasla.Enabled = false;
            btncevab.Enabled = false;
            btnsureek.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sure2 = Convert.ToInt32(lbltimer.Text);
            sure2 = sure2 - 1;
            lblekstra.Text = sure2.ToString();
            if (sure2 == 0)
            {
                timer2.Enabled = false;
                btncevab.Enabled = true;
                btna.Enabled = false;
                btnb.Enabled = false;
                btnc.Enabled = false;
                btnd.Enabled = false;
                btnsureek.Enabled = true;
                eliijokerimenu.Enabled = false;
                syrcmenu.Enabled = false;
                panel6.Visible = false;
            }
        }
        int sira = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            
            sira++;
            if (sira>7 && sira<=10)
            {
                panel6.Visible = false;
                btna.BackColor = Color.Gray;
                btna.Visible = true;
                btna.Enabled = true;
            }
            if (sira>10 && sira<=13)
            {
                btnb.BackColor = Color.Gray;
                btnb.Visible = true;
                btnb.Enabled = true;
            }
            if (sira > 13 && sira <= 15)
            {
                btnc.BackColor = Color.Gray;
                btnc.Visible = true;
                btnc.Enabled = true;
            }
            if (sira > 15 && sira <= 18)
            {
                btnd.BackColor = Color.Gray;
                btnd.Visible = true;
                btnd.Enabled = true;
            }
            if (sira==18)
            {
                sira = 0;
                timer3.Enabled = false;
                btna.BackColor = Color.Teal;
                btnb.BackColor = Color.Teal;
                btnc.BackColor = Color.Teal;
                btnd.BackColor = Color.Teal;
                btna.ForeColor = Color.White;
                btnb.ForeColor = Color.White;
                btnc.ForeColor = Color.White;
                btnd.ForeColor = Color.White;
                eliijokerimenu.Enabled = true;
                syrcmenu.Enabled = true;
            }

        }
        int hak = 0;
        private void jOKERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lblsoru.Text=="00")
            {
                MessageBox.Show("LÜTFEN YARIŞMA BAŞLA BUTONUNA TIKLAYIN");
            }
            else
            {
                panel5.Visible = true;
                
                if (lblelli.Text==numericUpDown1.Value.ToString())
                {
                    MessageBox.Show("%50 JOKERİNİZ BİTMİŞTİR");
                }
                else
                {
                    hak = hak + 1;
                    lblelli.Text = hak.ToString();
                    if (lbldogrucevapgoster.Text == btna.Text || lbldogrucevapgoster.Text == btnb.Text)
                    {
                        btnc.Visible = false;
                        btnd.Visible = false;
                    }
                    if (lbldogrucevapgoster.Text == btnc.Text || lbldogrucevapgoster.Text == btnd.Text)
                    {
                        btna.Visible = false;
                        btnb.Visible = false;
                    }
                }
                
            }
        }
        int hak2 = 0;
        private void sEYİRCİJOKERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lblsoru.Text == "00")
            {
                MessageBox.Show("LÜTFEN YARIŞMA BAŞLA BUTONUNA TIKLAYIN");
            }
            else
            {
                panel5.Visible = true;
                panel6.Visible = true;
                if (lblseyirci.Text==numericUpDown2.Value.ToString())
                {
                    MessageBox.Show("SEYİRCİ JOKERİNİZ BİTMİŞTİR");
                }
                else
                {
                    hak2 = hak2 + 1;
                    lblseyirci.Text = hak2.ToString();
                    Random rastgele = new Random();
                    string[] baslangic = { "A", "B", "C", "D" };
                    int index = rastgele.Next(baslangic.Length);
                    lblseyircicvp.Text = baslangic[index].ToString();
                }
                
            }
        }

        void sonuc()
        {
            MessageBox.Show("SAYIN YARIŞMACI: \n DOĞRU : " + lbldogrusayi.Text + "\n YANLIŞ : " + lblyanlissayi.Text + "\n PUAN : " + lblpuan.Text + "\n %50 JOKERİ : " + lblelli.Text + "\n SEYİRCİ JOKERİ : " + lblseyirci.Text + "", "YARIŞMA ÖZETİNİZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (lblsoru.Text == "00")
            {
                MessageBox.Show("LÜTFEN YARIŞMA BAŞLA BUTONUNA TIKLAYIN");
            }
            else
            {
                sonuc();
            }
        }

        private void btngrp_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
        void ayarlar()
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT * FROM ayarlar WHERE DEGER='" + lbldeger.Text + "'", baglanti);
            SqlDataReader okuyucu1 = komut2.ExecuteReader();
            while (okuyucu1.Read())
            {
                //string v = okuyucu1["ELLİJOKER"].ToString();
                numericUpDown2.Value = Convert.ToDecimal(okuyucu1["ELLİJOKER"].ToString());
                //string v1 = okuyucu1["SEYİRCİJOKER"].ToString();
                numericUpDown2.Value = Convert.ToDecimal(okuyucu1["SEYİRCİJOKER"].ToString());

            }
            baglanti.Close();
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (lbltimer.Text=="00")
            {
                panelayar.Visible = true;
                this.BackColor = Color.White;
                ayarlar();
            }
            else
            {
                MessageBox.Show("YARIŞMA HALİNDE AYARLAR DEĞİŞTİRELEMEZ");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelayar.Visible = false;
            this.BackColor = Color.WhiteSmoke;

            if (numericUpDown1.Value==0 || numericUpDown2.Value==0)
            {
                MessageBox.Show("LÜTFEN BOŞ ALANLARI DOLDURUNUZ");
            }
            else
            {
                baglanti.Open();
                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = baglanti;
                cmd3.CommandText = "UPDATE ayarlar SET ELLİJOKER='" + numericUpDown1.Value + "',SEYİRCİJOKER='" + numericUpDown2.Value + "' where DEGER=@deger";
                cmd3.Parameters.AddWithValue("@deger", lbldeger.Text.ToString());
                cmd3.ExecuteNonQuery();
                cmd3.Dispose();
                baglanti.Close();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (lbltimer.Text == "00")
            {
                Form4 frm4 = new Form4();
                frm4.Show();
            }
            else
            {
                MessageBox.Show("YARIŞMA HALİNDE KURALLARA BAKILAMAZ");
            }
        }

        private void sKORKAYITİŞLEMLERİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Z TECHNOLOGY  TÜM HAKLARI SAKLIDIR.2022", "ADMIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("İLETİŞİM : yorulmaz7279@gmail.com adresinden bize ulaşabilirsiniz", "ADMIN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
