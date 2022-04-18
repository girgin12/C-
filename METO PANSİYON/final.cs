using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace METO_PANSİYON
{
    public partial class final : Form
    {
        public final()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=muhammetgirgin;Integrated Security=True");

        private void verilerigoster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * muhammetgirgin", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Musteriid"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["TC"].ToString());
           
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }
        int id = 0;
        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TxtAdi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtno.Text = listView1.SelectedItems[0].SubItems[6].Text;
       
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
          SqlCommand komut = new SqlCommand("update Musteri_ekle set Adi='" + TxtAdi.Text + "'    where id=" + id + "", baglanti);

            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigoster();

        }

        private void Btnsil_Click(object sender, EventArgs e)
        {
            if(TxtAdi.Text == "adi")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from muhammetgirgin", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                verilerigoster();
            }
        

        }

        private void Btntemizle_Click(object sender, EventArgs e)
        {
            TxtAdi.Clear();
          
            txtno.Clear();
          
        }

        private void Btnara_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from muhammetgirgin where  Ad like '%"+textBox1.Text+"%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
           
                ekle.SubItems.Add(oku["TC"].ToString());
             

                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void final_Load_1(object sender, EventArgs e)
        {

        }
    }
}

