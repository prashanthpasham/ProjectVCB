using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace StudentCounseling
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        OpenFileDialog fd1 = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
           fd1.Filter = "image files|*.jpg;*.png;*.gif;*.icon;.*;";

            DialogResult dres1 = fd1.ShowDialog();

            if (dres1 == DialogResult.Abort)

                return;

            if (dres1 == DialogResult.Cancel)

                return;

            textBox5.Text = fd1.FileName;
 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !="" && textBox2.Text !="" && textBox3.Text !="" && textBox4.Text !="" && textBox5.Text !="")
            {
            //save the data 
            Profilepage f2 = new Profilepage();

            this.Hide();

            f2.label2.Text = textBox1.Text.ToString();

            f2.label6.Text = textBox2.Text.ToString();

           f2.label4.Text = textBox3.Text.ToString();

           f2.label8.Text = textBox4.Text.ToString();
            
           f2.pictureBox1.Image = Image.FromFile(fd1.FileName);

            MemoryStream ms1 = new MemoryStream();

            //f2.pictureBox1.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);

            f2.pictureBox1.Image.Save(ms1,System.Drawing.Imaging.ImageFormat.Jpeg);

           
            if (ms1.Length>25600)
            {
                MessageBox.Show("Please upload less than 25 kb image");
            }
            else{
            f2.Show();
            }
            }//if
            else{
                MessageBox.Show("Please enter your details correctly!");
            }

        }

        

    }//form profile

}//namespace
