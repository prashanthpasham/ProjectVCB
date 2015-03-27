using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentCounseling
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 ss = new Form3();
            ss.Show();
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 sh = new Form2();
            sh.Show();
            this.Hide();
        }

       

       
    }
}
