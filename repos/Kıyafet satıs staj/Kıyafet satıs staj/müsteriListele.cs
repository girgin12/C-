using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kıyafet_satıs_staj
{
    public partial class müsteriListele : Form
    {
        public müsteriListele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=kiyafetsatis;Integrated Security=True");
        DataSet daset = new DataSet();
        private void müsteriListele_Load(object sender, EventArgs e)
        {
            kayit_göster();
        }

        private void kayit_göster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from müsteri", baglanti);
            adtr.Fill(daset, "müsteri");
            dataGridView1.DataSource = daset.Tables["müsteri"];
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txttc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            txtadsoyad.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            txttel.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtadres.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            txtemail.Text= dataGridView1.CurrentRow.Cells["email"].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update müsteri set adsoyad=@adsoyad,telefon=@telefon,adres=@adres,email=@email where tc=@tc", baglanti);

            komut.Parameters.AddWithValue("@tc", txttc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtadsoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txttel.Text);
            komut.Parameters.AddWithValue("@adres", txtadres.Text);
            komut.Parameters.AddWithValue("@email", txtemail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["müsteri"].Clear();
            kayit_göster();
            MessageBox.Show("kayıt başarı ile güncellendi.");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from müsteri where tc ='"+dataGridView1.CurrentRow.Cells["tc"].Value.ToString()+"'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["müsteri"].Clear();
            kayit_göster();
            MessageBox.Show("kayıt silindi.");


        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
           SqlDataAdapter adtr = new SqlDataAdapter("select *from müsteri where tc like '%"+txtara.Text+"%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();



        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtadres_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtadsoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
