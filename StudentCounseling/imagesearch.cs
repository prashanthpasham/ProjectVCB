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
using System.Data.SqlClient;


namespace StudentCounseling
{
    public partial class imagesearch : Form
    {
        public imagesearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
//submit
             string myConnection = "datasource=localhost;port=3306;database=studentcounseling;username=root;password=2015";

                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand sda = new MySqlCommand(" SELECT * FROM studentcounseling.profiledata where Rollnumber='" + this.textBox1.Text + "' ;", myConn);
                myConn.Open();

            try

            {

 

                MySqlDataReader dr = sda.ExecuteReader();

                if (dr.Read())

                {

                    byte[] img_arr1 = (byte[])dr["image"];

                    

                    MemoryStream ms1 = new MemoryStream(img_arr1);

                    

                    ms1.Seek(0, SeekOrigin.Begin);

                   

                    pictureBox1.Image = Image.FromStream(ms1);

                    

                }

                else

                {

             MessageBox.Show("Your Data is not inserted in database try again");

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);

            }

            finally

            {

                myConn.Close();

            }


        }
    }
}
