using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaz2Lab1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button1.BackColor = Color.Green;
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.kullaniciAdi = textBox1.Text;
            frm.Show();
        }
    }
}
