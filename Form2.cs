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
    public partial class form2 : Form
    {
        public form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=THEYORULMAZZ;Initial Catalog=QUIZPROGRAM;Integrated Security=True");
        DataTable tablo = new DataTable();

        void listele()
        { 
            rtxtform2.Text = "";
            txta.Text = "";
            txtb.Text = "";
            txtc.Text = "";
            txtd.Text = "";
            txtdogru.Text = "";
            txtkonu.Text = "";
            rdbg.Text = "";
            rdbf.Text = "";
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from sorular", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            adtr.Dispose();
            baglanti.Close();
        }

        void sayac()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select count(*) from sorular",baglanti);
            SqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                lblsnc.Text = okuyucu[0].ToString();
            }
            baglanti.Close();
        }

        void kontrol()
        {
            rtxtform2.Text = rtxtform2.Text.Replace("'", "''");
            txta.Text = txta.Text.Replace("'", "''");
            txtb.Text = txtb.Text.Replace("'", "''");
            txtc.Text = txtc.Text.Replace("'", "''");
            txtd.Text = txtd.Text.Replace("'", "''");
            txtkonu.Text = txtkonu.Text.Replace("'", "''");
            
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            if (rtxtform2.Text.Trim() == "") errorProvider1.SetError(rtxtform2, "Boş Geçilemez");
            if (txta.Text.Trim() == "") errorProvider1.SetError(txta, "Boş Geçilemez");
            if (txtb.Text.Trim() == "") errorProvider1.SetError(txtb, "Boş Geçilemez");
            if (txtc.Text.Trim() == "") errorProvider1.SetError(txtc, "Boş Geçilemez");
            if (txtd.Text.Trim() == "") errorProvider1.SetError(txtd, "Boş Geçilemez");
            if (txtdogru.Text.Trim() == "") errorProvider1.SetError(txtdogru, "Boş Geçilemez");
            if (txtkonu.Text.Trim() == "") errorProvider1.SetError(txtkonu, "Boş Geçilemez");
            if (txtsinif.Text.Trim() == "") errorProvider1.SetError(txtsinif, "Boş Geçilemez");
            
            else
            {
                kontrol();
                baglanti.Open();
                SqlCommand komut1 = new SqlCommand();
                komut1.Connection = baglanti;
                komut1.CommandText = "INSERT INTO sorular(SORU,A,B,C,D,DOGRU,KONUSU,SORUNUNSAYISI,SINIF)VALUES('" + rtxtform2.Text + "','" + txta.Text + "','" + txtb.Text + "','" + txtc.Text + "','" + txtd.Text + "','" + txtdogru.Text + "','" + txtkonu.Text + "','" + lblsnc.Text + "','" + txtsinif.Text + "')";
                komut1.ExecuteNonQuery();
                tablo.Clear();
                baglanti.Close();
                MessageBox.Show("SORU KAYIT EDİLDİ","SİSTEM",MessageBoxButtons.OK,MessageBoxIcon.Information);
                sayac();
                listele();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //rtxtform2.Text = "deneme";
            //txta.Text = "deneme";
            //txtb.Text = "deneme";
            //txtc.Text = "deneme";
            //txtd.Text = "deneme";
            //txtdogru.Text = "deneme";
            //txtkonu.Text= "deneme";

            //baglanti.Open();
            //SqlCommand komut1 = new SqlCommand();
            //komut1.Connection = baglanti;
            //komut1.CommandText = "INSERT INTO sorular(SORU,A,B,C,D,DOGRU,KONUSU,SORUNUNSAYISI)VALUES('" + rtxtform2.Text + "','" + txta.Text + "','" + txtb.Text + "','" + txtc.Text + "','" + txtd.Text + "','" + txtdogru.Text + "','" + txtkonu.Text + "','" + lblsnc.Text + "')";
            //komut1.ExecuteNonQuery();
            //baglanti.Close();
            sayac();
            listele();
            rdbauto.Checked = true;
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if(rtxtform2.Text=="")
            {
                MessageBox.Show("LÜTFEN LİSTEDEN BİR KAYIT SEÇİN", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                kontrol();
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "UPDATE sorular SET SORU='" + rtxtform2.Text + "',A='" + txta.Text + "',B='" + txtb.Text + "',C='" + txtc.Text + "',D='" + txtd.Text + "',DOGRU='" + txtdogru.Text + "',KONUSU='" + txtkonu.Text + "',SORUNUNSAYISI='" + txtsıralama.Text + "',SINIF='" + txtsinif.Text + "'where ID=@NUMARA";
                cmd.Parameters.AddWithValue("@NUMARA", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                tablo.Clear();
                baglanti.Close();
                MessageBox.Show("SORU GÜNCELLEME İŞLEMİ TAMAMLANDI", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if(rtxtform2.Text=="")
            {
                MessageBox.Show("LÜTFEN LİSTEDEN BİR KAYIT SEÇİN", "SİSTEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(MessageBox.Show("SORU SİLİNSİNMİ ?","SİSTEM",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk)==DialogResult.Yes)
                {
                    baglanti.Open();
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = baglanti;
                    cmd2.CommandText = "DELETE FROM sorular WHERE ID=@NUMARA";
                    cmd2.Parameters.AddWithValue("@NUMARA", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    cmd2.ExecuteNonQuery();
                    tablo.Clear();
                    baglanti.Close();     
                }
            }
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rtxtform2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txta.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtb.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtc.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtd.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtdogru.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtkonu.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtsıralama.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtsinif.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void rdbauto_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbauto.Checked==true)
            {
                txtsıralama.Enabled = false;
            }
        }

        private void rdbmanuel_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbmanuel.Checked==true)
            {
                txtsıralama.Enabled = true;
            }
        }

        private void btnplay_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void btndownload_Click(object sender, EventArgs e)
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

       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbhepsi.Checked == true)
            {
                tablo.Clear();
                baglanti.Open();
                SqlDataAdapter adtr3 = new SqlDataAdapter("select * from sorular", baglanti); ;
                adtr3.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr3.Dispose();
                baglanti.Close();

            }
        }

        private void rdbg_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbg.Checked == true)
            {
                tablo.Clear();
                baglanti.Open();
                SqlDataAdapter adtr2 = new SqlDataAdapter("select * from sorular where SINIF like'%G" + rdbg.Text + "%'", baglanti); ;
                adtr2.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr2.Dispose();
                baglanti.Close();

            }

        }

        private void rdbf_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbf.Checked == true)
            {
                tablo.Clear();
                baglanti.Open();
                SqlDataAdapter adtr4 = new SqlDataAdapter("select * from sorular where SINIF like'%F" + rdbf.Text + "%'", baglanti); ;
                adtr4.Fill(tablo);
                dataGridView1.DataSource = tablo;
                adtr4.Dispose();
                baglanti.Close();

            }

        }

        private void txtsıralama_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtkonu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
