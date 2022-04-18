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
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection adres = new SqlConnection("Data Source=DESKTOP-FOPHVBV\\SQLEXPRESS;Initial Catalog=muhammet;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'muhammetDataSet1.muhammet' table. You can move, or remove it, as needed.
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.muhammetTableAdapter.Fill(this.muhammetDataSet1.muhammet);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            adres.Open();
            SqlCommand komutekle = new SqlCommand("insert into muhammet(AD) values (@AD)", adres);
            komutekle.Parameters.AddWithValue("@AD", textBox2.Text);
            komutekle.ExecuteNonQuery();
            MessageBox.Show("Ekleme işlemi başarı ile gerçekleştirildi.");
            adres.Close();
            this.muhammetTableAdapter.Fill(this.muhammetDataSet1.muhammet);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adres.Open();
            SqlCommand komutsil = new SqlCommand("delete from muhammet where ID=@sil", adres);
            komutsil.Parameters.AddWithValue("@sil", textBox1.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Silme işlemi başarı ile gerçekleştirildi.");
            adres.Close();
            this.muhammetTableAdapter.Fill(this.muhammetDataSet1.muhammet);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            adres.Open();
            SqlCommand komutgüncelle = new SqlCommand("update muhammet set AD=@AD where  ID=@ID", adres);
            komutgüncelle.Parameters.AddWithValue("@ID", textBox1.Text);
            komutgüncelle.Parameters.AddWithValue("@AD", textBox2.Text);
            komutgüncelle.ExecuteNonQuery();
            MessageBox.Show("Güncelleme işlemi başarı ile gerçekleştirildi.");
            adres.Close();
            this.muhammetTableAdapter.Fill(this.muhammetDataSet1.muhammet);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int tiklananhücre = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[tiklananhücre].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[tiklananhücre].Cells[1].Value.ToString();
        }
    }
}
