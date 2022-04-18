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
namespace Kıyafet_satıs_staj
{
    public partial class müsteriekle : Form
    {
        public müsteriekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=kiyafetsatis;Integrated Security=True");
        private void müsteriekle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into müsteri(tc,adsoyad,telefon,adres,email) values(@tc,@adsoyad,@telefon,@adres,@email)", baglanti);
            komut.Parameters.AddWithValue("@tc",txttc.Text);
            komut.Parameters.AddWithValue("@adsoyad",txtadsoyad.Text);
            komut.Parameters.AddWithValue("@telefon",txttel.Text);
            komut.Parameters.AddWithValue("@adres",txtadres.Text);
            komut.Parameters.AddWithValue("@email",txtemail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kayıt başarı ile eklendi.");
            foreach(Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
    }
}
