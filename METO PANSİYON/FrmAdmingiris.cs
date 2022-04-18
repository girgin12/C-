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
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=Metopansiyon;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Btngirisyap_Click(object sender, EventArgs e)
        {
            try
            {

            
            baglanti.Open();
            string sql = "select * from Admingiris where Kullanici=@Kullaniciadi AND Sifre=@Sifresi";
            SqlParameter prm1 = new SqlParameter("Kullaniciadi", TxtKullaniciadi.Text.Trim());
            SqlParameter prm2 = new SqlParameter("Sifresi", TxtSifre.Text.Trim());
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.Add(prm1);
            komut.Parameters.Add(prm2);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                AnaForm fr = new AnaForm();
                fr.Show();
                    this.Hide();
            }

        }
        catch(Exception)
            {
                MessageBox.Show("Hatalı Giriş MURAT ABİ ");
            }

        }

        private void TxtKullaniciadi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
