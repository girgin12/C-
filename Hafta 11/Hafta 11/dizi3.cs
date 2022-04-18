using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hafta_11
{
    public partial class dizi3 : Form
    {
        public dizi3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] sayilar = { 5, 9, 12 };
            int toplam = 0;
            for( int i = 0; i< sayilar.Length; i++)
            {
                toplam = toplam + sayilar[i];
                label1.Text = toplam.ToString();
            }
        }
    }
}
