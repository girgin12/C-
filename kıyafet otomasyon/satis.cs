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
    public partial class Satis : Form
    {
        public Satis()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=kiyafetsatis;Integrated Security=True");
           DataSet daset = new DataSet();


        private void sepetlistele()
        {
            baglanti.Open();

            SqlDataAdapter adtr = new SqlDataAdapter("select *from sepet", baglanti);  
            adtr.Fill(daset,"sepet");
            dataGridView1.DataSource = daset.Tables["sepet"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            baglanti.Close();


        }

         

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void hesapla()
        {
            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select sum(toplamfiyat) from sepet", baglanti);
                label10.Text = komut.ExecuteScalar() + "TL";
                baglanti.Close();
            }
            catch (Exception)
            {

                ;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sepetlistele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            müsteriekle ekle = new müsteriekle();
            ekle.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            müsteriListele listele = new müsteriListele();
            listele.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            personelEkle perekle = new personelEkle();
            perekle.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PersonelListele perlist = new PersonelListele();
            perlist.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ürünEkle ekle = new ürünEkle();
            ekle.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Kategori ekle = new Kategori();
            ekle.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            marka ekle = new marka();
            ekle.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ÜrünListeleme listele = new ÜrünListeleme();
            listele.ShowDialog();

        }

        private void txttc_TextChanged(object sender, EventArgs e)
        {
            if(txttc.Text=="")
            {
                txtadsoyad.Text = "";
                txttel.Text = "";

            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from müsteri where tc like'"+txttc.Text+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read())
            {

                txtadsoyad.Text = read["adsoyad"].ToString();
               txttel.Text = read["telefon"].ToString();
            }
            baglanti.Close();
        }

        private void txtbarkodno_TextChanged(object sender, EventArgs e)
        {
            Temizle();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from ürün where Barkodno like'" + txtbarkodno.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {

                txturunadi.Text = read["ürünadi"].ToString();
                txtsatisfiyat.Text = read["satisfiyat"].ToString();
            }
            baglanti.Close();
        }

        private void Temizle()
        {
            if (txtbarkodno.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtmiktar)
                        {

                            item.Text = "";
                        }
                    }

                }
            }
        }


        bool durum;
        private void barkodkontrol()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from sepet", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while(read.Read())
            {

                if (txtbarkodno.Text==read["barkodno"].ToString())
                {
                    durum = false;
                }
            }
            baglanti.Close();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            barkodkontrol();
            if(durum==true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into sepet(tc,adsoyad,telefon,barkodno,ürünadi,miktari,satisfiyati,toplamfiyat,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@ürünadi,@miktari,@satisfiyati,@toplamfiyat,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@tc", txttc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtadsoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txttel.Text);
                komut.Parameters.AddWithValue("@barkodno", txtbarkodno.Text);
                komut.Parameters.AddWithValue("@ürünadi", txturunadi.Text);
                komut.Parameters.AddWithValue("@miktari", int.Parse(txtmiktar.Text));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtsatisfiyat.Text));
                komut.Parameters.AddWithValue("@toplamfiyat", double.Parse(txttoplamfiyat.Text));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("update sepet miktari=miktari+'"+int.Parse(txtmiktar.Text)+ "' where barkodno='" + txtbarkodno.Text + "'", baglanti);
                komut2.ExecuteNonQuery();
                SqlCommand komut3 = new SqlCommand("update sepet toplamfiyat=miktari*satisfiyati where barkodno='"+txtbarkodno.Text+"'", baglanti);
                komut3.ExecuteNonQuery();
                baglanti.Close();
            }
           
            txtmiktar.Text = "1";
            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    if (item != txtmiktar)
                    {

                        item.Text = "";
                    }
                }

            }



        }

        private void txtmiktar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txttoplamfiyat.Text =(double.Parse (txtmiktar.Text) * double.Parse(txtsatisfiyat.Text)).ToString();
            }
            catch (Exception)
            {

               ;
            }
        }

        private void txtsatisfiyat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txttoplamfiyat.Text = (double.Parse(txtmiktar.Text) * double.Parse(txtsatisfiyat.Text)).ToString();
            }
            catch (Exception)
            {

                ;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from sepet where barkodno='"+dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString()+"'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            
            MessageBox.Show("Ürün Sepetten Çıkarıldı.");
            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
        }

        private void btnsatısıptal_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from sepet ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            
            MessageBox.Show("Ürünler Sepetten Çıkarıldı.");
            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SatisListele listele = new SatisListele();
            listele.ShowDialog();
        }

        private void btnsatısyap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into satis(tc,adsoyad,telefon,barkodno,ürünadi,miktari,satisfiyati,toplamfiyat,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@ürünadi,@miktari,@satisfiyati,@toplamfiyat,@tarih)", baglanti);
                komut.Parameters.AddWithValue("@tc", txttc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtadsoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txttel.Text);
                komut.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                komut.Parameters.AddWithValue("@ürünadi", dataGridView1.Rows[i].Cells["ürünadi"].Value.ToString());
                komut.Parameters.AddWithValue("@miktari", int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(dataGridView1.Rows[i].Cells["satisfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@toplamfiyat", double.Parse(dataGridView1.Rows[i].Cells["toplamfiyat"].Value.ToString()));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                SqlCommand komut2 = new SqlCommand("update ürün set miktari=miktari-'" + int.Parse((dataGridView1.Rows[i].Cells["miktari"].Value.ToString())) + "' where Barkodno='" + dataGridView1.Rows[i].Cells["miktari"].Value.ToString() + "'  ", baglanti);
                komut2.ExecuteNonQuery();
                baglanti.Close();
         
               
            }

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from sepet ", baglanti);
            komut3.ExecuteNonQuery();
            baglanti.Close();

            daset.Tables["sepet"].Clear();
            sepetlistele();
            hesapla();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
