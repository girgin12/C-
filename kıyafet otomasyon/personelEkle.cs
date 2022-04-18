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
    public partial class personelEkle : Form
    {
        public personelEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=kiyafetsatis;Integrated Security=True");
        private void label8_Click(object sender, EventArgs e)
        {

        }

        
          

        private void button1_Click(object sender, EventArgs e)
        {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into personel(tc,adsoyad,telefon,adres,email,bölüm,yas,cinsiyet) values(@tc,@adsoyad,@telefon,@adres,@email,@bölüm,@yas,@cinsiyet)", baglanti);
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
                MessageBox.Show("personel kaydı başarı ile eklendi.");
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }
    }

