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
    public partial class ürünEkle : Form
    {
        public ürünEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=kiyafetsatis;Integrated Security=True");
        bool durum;
        private void barkodkontrol()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from ürün", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (TxtbarkodNo.Text==read["Barkodno"].ToString() || TxtbarkodNo.Text=="")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }

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

        private void ürünEkle_Load(object sender, EventArgs e)
        {
            kategorigetir();
        }

        private void combokategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                combomarka.Items.Clear();
                combomarka.Text = "";
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select  *from markabilgileri where kategori='"+combokategori.SelectedItem+"'", baglanti);
                SqlDataReader read = komut.ExecuteReader();
                while (read.Read())
                {
                    combomarka.Items.Add(read["marka"].ToString());
                }
                baglanti.Close();
            }
        }

        private void btnyeniekle_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if(durum== true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into ürün(Barkodno,kategori,marka,ürünadi,miktari,alisfiyat,satisfiyat,tarih) values(@Barkodno,@kategori,@marka,@ürünadi,@miktari,@alisfiyat,@satisfiyat,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@Barkodno", TxtbarkodNo.Text);
                komut.Parameters.AddWithValue("@kategori", combokategori.Text);
                komut.Parameters.AddWithValue("@marka", combomarka.Text);
                komut.Parameters.AddWithValue("@ürünadi", txturunadi.Text);
                komut.Parameters.AddWithValue("@miktari", int.Parse(txtmiktar.Text));
                komut.Parameters.AddWithValue("@alisfiyat", double.Parse(txtalisfiyat.Text));
                komut.Parameters.AddWithValue("@satisfiyat", double.Parse(txtsatisfiyat.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün Eklendi.");
            }
             else
            {

                MessageBox.Show("Böyle Bir Barkod no Var", "Uyarı");
            }
            combomarka.Items.Clear();
            foreach (Control item in groupBox1.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void barkodnotxt_TextChanged(object sender, EventArgs e)
        {
            if(barkodnotxt.Text=="")
            {
                lblmiktari.Text = "";
                foreach(Control item in groupBox2.Controls)
                {
                    if(item is TextBox)
                        {

                        item.Text = "";
                         }
                }
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from ürün where Barkodno like '"+barkodnotxt.Text+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read())
            {
                kategoritxt.Text = read["kategori"].ToString();
                markatxt.Text = read["marka"].ToString();
                ürünaditxt.Text = read["ürünadi"].ToString();
                lblmiktari.Text = read["miktari"].ToString();
                alisfiyattxt.Text = read["alisfiyat"].ToString();
                satisfiyattxt.Text = read["satisfiyat"].ToString();

            }
            baglanti.Close();

        }

        private void btnvarolanaekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update ürün set miktari=miktari+'"+int.Parse(miktartxt.Text)+"' where Barkodno='"+barkodnotxt.Text+"'  ",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {

                    item.Text = "";
                }
            }
            MessageBox.Show("Var olan ürüne ekleme yapıldı.");
         }
    }
}
