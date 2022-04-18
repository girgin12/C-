using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace final

{
    public partial class VeriGoster : Form
    {
        public VeriGoster()
        {
            InitializeComponent();
        }
        static string conString = "Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=Metopansiyon;Integrated Security=True";
        //Bu veritabanına bağlanmak için gerekli olan bağlantı cümlemiz.Bu satıra dikkat edelim.
        //Sql Servera bağlanırken kullandığımız bilgileri ve veritabanı ismini yazıyoruz.
        SqlConnection baglanti = new SqlConnection(conString);
        //bağlantı cümlemizi kullanarak bir SqlConnection bağlantısı oluşturuyoruz.

        private void VeriGoster_Load(object sender, EventArgs e)
        {
            kayitGetir();
            //Tüm kayıtları gösterecek olan kayitGetir() metodumuzu çağırıyoruz.
        }

        private void kayitGetir()
        {
            baglanti.Open();
            string kayit = "SELECT * from muhammetgirgin";
            //musteriler tablosundaki tüm kayıtları çekecek olan sql sorgusu.
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
            dataGridView1.DataSource = dt;
            //Formumuzdaki DataGridViewin veri kaynağını oluşturduğumuz tablo olarak gösteriyoruz.
            baglanti.Close();
        }

    }
}