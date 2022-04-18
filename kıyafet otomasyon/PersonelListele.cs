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
    public partial class PersonelListele : Form
    {
        public PersonelListele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=kiyafetsatis;Integrated Security=True");
        DataSet daset = new DataSet();
        private void PersonelListele_Load(object sender, EventArgs e)
        {
            kayit_göster();
        }


        private void kayit_göster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from personel", baglanti);
            adtr.Fill(daset, "personel");
            dataGridView1.DataSource = daset.Tables["personel"];
            baglanti.Close();
        }
       
     
    
       

        private void btnsil_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from personel where tc ='" + dataGridView1.CurrentRow.Cells["tc"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["personel"].Clear();
            kayit_göster();
            MessageBox.Show("kayıt silindi.");

        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from personel where tc like '%" + txtara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update personel set adsoyad=@adsoyad,telefon=@telefon,adres=@adres,email=@email,bölüm=@bölüm,yas=@yas,cinsiyet=@cinsiyet  where tc=@tc", baglanti);

                komut.Parameters.AddWithValue("@tc", txttc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtadsoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txttel.Text);
                komut.Parameters.AddWithValue("@adres", txtadres.Text);
                komut.Parameters.AddWithValue("@email", txtemail.Text);
                komut.Parameters.AddWithValue("@bölüm", txtbolum.Text);
                komut.Parameters.AddWithValue("@yas", txtyas.Text);
                komut.Parameters.AddWithValue("@cinsiyet", txtcinsiyet.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                daset.Tables["personel"].Clear();
                kayit_göster();
                MessageBox.Show("personel verisi  başarı ile güncellendi.");
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txttc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            txtadsoyad.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            txttel.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtadres.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            txtemail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
            txtbolum.Text = dataGridView1.CurrentRow.Cells["bölüm"].Value.ToString();
            txtyas.Text = dataGridView1.CurrentRow.Cells["yas"].Value.ToString();
            txtcinsiyet.Text = dataGridView1.CurrentRow.Cells["cinsiyet"].Value.ToString();
        }
    }
}
