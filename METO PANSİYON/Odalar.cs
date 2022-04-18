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
    public partial class Odalar : Form
    {
        public Odalar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=Metopansiyon;Integrated Security=True");
       
        private void Odalar_Load(object sender, EventArgs e)
        { //ODA101
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from Oda101", baglanti);
            SqlDataReader oku1 = komut1.ExecuteReader();

            while (oku1.Read())
            {
                Btnoda101.Text = oku1["Adi"].ToString() + " " + oku1["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda101.Text != "101")
            {
                Btnoda101.BackColor = Color.Red;
            }
            //ODA102
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from Oda102", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                Btnoda102.Text = oku2["Adi"].ToString() + " " + oku2["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda102.Text != "102")
            {
                Btnoda102.BackColor = Color.Red;
            }
            //ODA103
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select * from Oda103", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();

            while (oku3.Read())
            {
                Btnoda103.Text = oku3["Adi"].ToString() + " " + oku3["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda103.Text != "103")
            {
                Btnoda103.BackColor = Color.Red;
            }
            //ODA104
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select * from Oda104", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();

            while (oku4.Read())
            {
                Btnoda104.Text = oku4["Adi"].ToString() + " " + oku4["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda104.Text != "104")
            {
                Btnoda104.BackColor = Color.Red;
            }
            //ODA105
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select * from Oda105", baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();

            while (oku5.Read())
            {
                Btnoda105.Text = oku5["Adi"].ToString() + " " + oku5["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda105.Text != "105")
            {
                Btnoda105.BackColor = Color.Red;
            }
            //ODA106
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select * from Oda106", baglanti);
            SqlDataReader oku6 = komut6.ExecuteReader();

            while (oku6.Read())
            {
                Btnoda106.Text = oku6["Adi"].ToString() + " " + oku6["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda106.Text != "106")
            {
                Btnoda106.BackColor = Color.Red;
            }
            //ODA107
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("select * from Oda107", baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();

            while (oku7.Read())
            {
                Btnoda107.Text = oku7["Adi"].ToString() + " " + oku7["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda107.Text != "107")
            {
                Btnoda107.BackColor = Color.Red;
            }
            //ODA108
            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("select * from Oda108", baglanti);
            SqlDataReader oku8 = komut8.ExecuteReader();

            while (oku8.Read())
            {
                Btnoda108.Text = oku8["Adi"].ToString() + " " + oku8["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda108.Text != "108")
            {
                Btnoda108.BackColor = Color.Red;
            }
            //ODA109
            baglanti.Open();
            SqlCommand komut9 = new SqlCommand("select * from Oda109", baglanti);
            SqlDataReader oku9 = komut9.ExecuteReader();

            while (oku9.Read())
            {
                Btnoda109.Text = oku9["Adi"].ToString() + " " + oku9["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda109.Text != "109")
            {
                Btnoda109.BackColor = Color.Red;
            }
            //ODA110
            baglanti.Open();
            SqlCommand komut10 = new SqlCommand("select * from Oda110", baglanti);
            SqlDataReader oku10 = komut10.ExecuteReader();

            while (oku10.Read())
            {
                Btnoda110.Text = oku10["Adi"].ToString() + " " + oku10["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda110.Text != "110")
            {
                Btnoda110.BackColor = Color.Red;
            }
            //ODA111
            baglanti.Open();
            SqlCommand komut11 = new SqlCommand("select * from Oda111", baglanti);
            SqlDataReader oku11 = komut11.ExecuteReader();

            while (oku11.Read())
            {
                Btnoda111.Text = oku11["Adi"].ToString() + " " + oku11["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda111.Text != "111")
            {
                Btnoda111.BackColor = Color.Red;
            }
            //ODA112
            baglanti.Open();
            SqlCommand komut12 = new SqlCommand("select * from Oda112", baglanti);
            SqlDataReader oku12 = komut12.ExecuteReader();

            while (oku12.Read())
            {
                Btnoda112.Text = oku12["Adi"].ToString() + " " + oku12["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda112.Text != "112")
            {
                Btnoda112.BackColor = Color.Red;
            }
            //ODA113
            baglanti.Open();
            SqlCommand komut13 = new SqlCommand("select * from Oda113", baglanti);
            SqlDataReader oku13 = komut13.ExecuteReader();

            while (oku13.Read())
            {
                Btnoda113.Text = oku13["Adi"].ToString() + " " + oku13["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda113.Text != "113")
            {
                Btnoda113.BackColor = Color.Red;
            }
            //ODA114
            baglanti.Open();
            SqlCommand komut14 = new SqlCommand("select * from Oda114", baglanti);
            SqlDataReader oku14 = komut14.ExecuteReader();

            while (oku14.Read())
            {
                Btnoda114.Text = oku14["Adi"].ToString() + " " + oku14["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda114.Text != "114")
            {
                Btnoda114.BackColor = Color.Red;
            }
            //ODA115
            baglanti.Open();
            SqlCommand komut15 = new SqlCommand("select * from Oda115", baglanti);
            SqlDataReader oku15 = komut15.ExecuteReader();

            while (oku15.Read())
            {
                Btnoda115.Text = oku15["Adi"].ToString() + " " + oku15["Soyadi"].ToString();
            }
            baglanti.Close();
            if (Btnoda115.Text != "115")
            {
                Btnoda115.BackColor = Color.Red;
            }

        }
    
      }
           
  }

