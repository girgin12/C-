﻿using System;
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
    public partial class Kategori : Form
    {
        public Kategori()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=kiyafetsatis;Integrated Security=True");

        bool durum;
        private void kategorikontrol()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kategoribilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read())
            {
                if (textBox1.Text == read["kategori"].ToString() || textBox1.Text=="")
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void Kategori_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kategorikontrol();
            if(durum==true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into kategoribilgileri(kategori) values('" + textBox1.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kategori EKlendi.");
            }
            else
            {
                MessageBox.Show("Böyle bir Kategori var","Uyarı");
            }
            textBox1.Text = "";



        }
    }
}
