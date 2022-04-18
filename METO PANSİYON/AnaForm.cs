using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace METO_PANSİYON
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminGiris fr = new AdminGiris();
            fr.Show();
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Yeni_Müsteri_Eklecs fr = new Yeni_Müsteri_Eklecs();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Odalar fr = new Odalar();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            final fr = new final();
            fr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu otomasyon sistemi Muhammet GİRGİN  tarafından METO PANSİYON için Geliştirilmiştir. 2020 TEKİRDAĞ");
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
