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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=OZCAN;Initial Catalog=QUIZPROGRAM;Integrated Security=True");
        DataTable tablo = new DataTable();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        void list()
        {
            txtgrupad.Clear();
            txtsrsayi.Clear();
            txtdcevap.Clear();
            txtycevap.Clear();
            txtpuan.Clear();
            txtoyuncubir.Clear();
            txtoyuncuiki.Clear();
            txtoyuncuuc.Clear();
            tablo.Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from skor", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtgrupad.Text.Trim() == "") errorProvider1.SetError(txtgrupad, "BOŞ GEÇİLEMEZ");
            if (txtsrsayi.Text.Trim() == "") errorProvider1.SetError(txtsrsayi, "BOŞ GEÇİLEMEZ");
            if (txtdcevap.Text.Trim() == "") errorProvider1.SetError(txtdcevap, "BOŞ GEÇİLEMEZ");
            if (txtycevap.Text.Trim() == "") errorProvider1.SetError(txtycevap, "BOŞ GEÇİLEMEZ");
            if (txtpuan.Text.Trim() == "") errorProvider1.SetError(txtpuan, "BOŞ GEÇİLEMEZ");
            if (txtoyuncubir.Text.Trim() == "") errorProvider1.SetError(txtoyuncubir, "BOŞ GEÇİLEMEZ");
            if (txtoyuncuiki.Text.Trim() == "") errorProvider1.SetError(txtoyuncuiki, "BOŞ GEÇİLEMEZ");
            if (txtoyuncuuc.Text.Trim() == "") errorProvider1.SetError(txtoyuncuuc, "BOŞ GEÇİLEMEZ");
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText="INSERT INTO skor(GRUP_ADI,SORU_SAYISI,D_CEVAP,Y_CEVAP,PUAN,OYUN_TARIHI,OYUNCU_1,OYUNCU_2,OYUNCU_3)VALUES('"+txtgrupad.Text+"','" + txtsrsayi.Text + "','" + txtdcevap.Text + "','" + txtycevap.Text + "','" + txtpuan.Text + "','" + dateTimePicker1.Text + "','" + txtoyuncubir.Text + "','" + txtoyuncuiki.Text + "','" + txtoyuncuuc.Text + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("SKOR KAYIT EDİLDİ");
                list();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (txtsrsayi.Text==""||txtdcevap.Text==""||txtycevap.Text=="")
            {
                MessageBox.Show("LÜTFEN LİSTEDEN BİR KAYIT SEÇİN");
            }
            else
            {
                if (MessageBox.Show("SKOR SİLİNSİNMİ ?", "SİSTEM", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand();
                    komut2.Connection = baglanti;
                    komut2.CommandText = "DELETE FROM skor WHERE ID=@numa";
                    komut2.Parameters.AddWithValue("@numa", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    list();
                }
            }
            
        }

        private void btnindir_Click(object sender, EventArgs e)
        {
            int sutun = 1;
            int satir = 1;
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Workbooks.Add();
            ExcelApp.Visible = true;
            ExcelApp.Worksheets[1].Activate();
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                ExcelApp.Cells[satir, sutun + j].Value = dataGridView1.Columns[j].HeaderText;

            }
            satir++;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    ExcelApp.Cells[satir + i, sutun + j].Value = dataGridView1[j, i].Value;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtgrupad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsrsayi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtdcevap.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtycevap.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtpuan.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtoyuncubir.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtoyuncuiki.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtoyuncuuc.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

        }
        int sayi;
        private void txtdcevap_TextChanged(object sender, EventArgs e)
        {
            if (txtdcevap.Text=="")
            {

            }
            else
            {
                sayi = Convert.ToInt32(txtdcevap.Text);
                sayi = sayi * 10;
                txtpuan.Text = sayi.ToString();
            }
            
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from skor where OYUN_TARIHI like'%"+dateTimePicker3.Text+"%'",baglanti); ;
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();
            baglanti.Close();
        }

        private void txtpuaniki_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            baglanti.Open();
            SqlDataAdapter adtr1 = new SqlDataAdapter("select * from skor where PUAN like'%" + txtpuaniki.Text + "%'", baglanti); ;
            adtr1.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr1.Dispose();
            baglanti.Close();
        }

        private void txtgadiki_TextChanged(object sender, EventArgs e)
        {
            tablo.Clear();
            baglanti.Open();
            SqlDataAdapter adtr2 = new SqlDataAdapter("select * from skor where GRUP_ADI like'%" + txtgadiki.Text + "%'", baglanti); ;
            adtr2.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr2.Dispose();
            baglanti.Close();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            list();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rdbhps_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbhps.Checked == true)
            {
                txtgadiki.Enabled = false;
                txtpuaniki.Enabled = false;
                dateTimePicker3.Enabled = false;
                tablo.Clear();
                baglanti.Open();
                SqlDataAdapter adtr5 = new SqlDataAdapter("select * from skor", baglanti); ;
                adtr5.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr5.Dispose();
                baglanti.Close();

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbmanuel.Checked == true)
            {
                txtgadiki.Enabled = true;
                txtpuaniki.Enabled = true;
                dateTimePicker3.Enabled = true;
            }
        }
    }
}
