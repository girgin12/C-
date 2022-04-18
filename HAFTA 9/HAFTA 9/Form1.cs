using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAFTA_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(sayac==100)
            {
                timer1.Stop();
            }
          
            progressBar1.Value = sayac;
            sayac++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
