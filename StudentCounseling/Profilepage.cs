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
using MySql.Data.MySqlClient;

namespace StudentCounseling
{
    public partial class Profilepage : Form
    {
        public Profilepage()
        {
            InitializeComponent();
        }

      /*  public bool convertImage()
        {
            try
            {
                MemoryStream ms1 = new MemoryStream();
                pictureBox1.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms1.Position = 0;
                byte[] img_arr1 = new byte[ms1.Length];

                ms1.Read(img_arr1, 0, img_arr1.Length);

                return true;
            }
            catch
            {
                MessageBox.Show("image can not be converted");
                return false;
            }
        }
       */
        private void button1_Click(object sender, EventArgs e)
        {
            


            //save the profile
          
            MemoryStream ms1 =new MemoryStream();
            pictureBox1.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
          byte[] img_arr1 = new byte[ms1.Length];
          ms1.Position = 0;
           
             ms1.Read(img_arr1,0, img_arr1.Length);

            

            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=studentcounseling;username=root;password=2015");

           con.Open();

           MySqlCommand cmd = new MySqlCommand("insert into studentcounseling.profiledata(Name,Rollnumber,Address,Phone,Image)values(@a,@b,@c,@d,@e)", con);

            cmd.Parameters.AddWithValue("@a", label2.Text);

            cmd.Parameters.AddWithValue("@b", label6.Text);

            cmd.Parameters.AddWithValue("@c", label4.Text);

            cmd.Parameters.AddWithValue("@d", label8.Text);

            cmd.Parameters.AddWithValue("@e",img_arr1);

            

            int result = cmd.ExecuteNonQuery();

            if (result > 0)

                MessageBox.Show("Your Profile Data has been inserted successfully");
                
           
            
            else

                MessageBox.Show("Data has not been inserted successfully");

            con.Close();

           


        }
    }
}
