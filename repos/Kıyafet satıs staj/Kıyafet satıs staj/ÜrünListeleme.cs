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
    public partial class ÜrünListeleme : Form
    {
        public ÜrünListeleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=kiyafetsatis;Integrated Security=True");
        DataSet daset = new DataSet();

        private void kategorigetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from kategoribilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combokategori.Items.Add(read["kategori"].ToString());
            }
            baglanti.Close();
        }
        private void ÜrünListeleme_Load(object sender, EventArgs e)
        {
            ürünlistele();
            kategorigetir();
        }

        private void ürünlistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from ürün", baglanti);
            adtr.Fill(daset, "ürün");
            dataGridView1.DataSource = daset.Tables["ürün"];
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            barkodnotxt.Text = dataGridView1.CurrentRow.Cells["Barkodno"].Value.ToString();
            kategoritxt.Text = dataGridView1.CurrentRow.Cells["kategori"].Value.ToString();
            markatxt.Text = dataGridView1.CurrentRow.Cells["marka"].Value.ToString();
            ürünaditxt.Text = dataGridView1.CurrentRow.Cells["ürünadi"].Value.ToString();
            miktartxt.Text = dataGridView1.CurrentRow.Cells["miktari"].Value.ToString();
            alisfiyattxt.Text = dataGridView1.CurrentRow.Cells["alisfiyat"].Value.ToString();
            satisfiyattxt.Text = dataGridView1.CurrentRow.Cells["satisfiyat"].Value.ToString();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update ürün set ürünadi=@ürünadi,miktari=@miktari,alisfiyat=@alisfiyat,satisfiyat=@satisfiyat where Barkodno=@Barkodno ", baglanti);
            komut.Parameters.AddWithValue("@Barkodno", barkodnotxt.Text);
            komut.Parameters.AddWithValue("@ürünadi", ürünaditxt.Text);
            komut.Parameters.AddWithValue("@miktari", int.Parse(miktartxt.Text));
            komut.Parameters.AddWithValue("@alisfiyat", double.Parse(alisfiyattxt.Text));
            komut.Parameters.AddWithValue("@satisfiyat", double.Parse(satisfiyattxt.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["ürün"].Clear();
            ürünlistele();
            MessageBox.Show("Güncelleme Başarılı.");
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void btnmarkaguncelle_Click(object sender, EventArgs e)
        {

            if(barkodnotxt.Text!="")
            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("update ürün set kategori=@kategori,marka=@marka where Barkodno=@Barkodno ", baglanti);
                komut.Parameters.AddWithValue("@Barkodno", barkodnotxt.Text);
                komut.Parameters.AddWithValue("@kategori", combokategori.Text);
                komut.Parameters.AddWithValue("@marka", combomarka.Text);

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme Başarılı.");
                daset.Tables["ürün"].Clear();
                ürünlistele();
            }
            else
            {

                MessageBox.Show("Barkod no Seçili veya yazılı Depil.");
            }
          
            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void combokategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            combomarka.Items.Clear();
            combomarka.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select  *from markabilgileri where kategori='" + combokategori.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combomarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from ürün where Barkodno ='" + dataGridView1.CurrentRow.Cells["Barkodno"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["ürün"].Clear();
            ürünlistele();
            MessageBox.Show("kayıt silindi.");
        }

        private void txtbarkodnoAra_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from ürün where Barkodno like '%" + txtbarkodnoAra.Text + "%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
