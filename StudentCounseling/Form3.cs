using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;



namespace StudentCounseling
{
    public partial class Form3 : Form
    {
       

        public Form3()
        {
            InitializeComponent();
            
        }
         
 


        DataTable dt;
       private void button1_Click(object sender, EventArgs e)
        {
            if (rollno_txt.Text != "")
            {
                DataGridViewRow row = this.dataGridView1.RowTemplate;
                row.DefaultCellStyle.BackColor = Color.Bisque;
                row.Height = 40;
                row.MinimumHeight = 20;
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;



                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToResizeColumns = false;

                string myConnection = "datasource=localhost;port=3306;database=studentcounseling;username=root;password=2015";

                MySqlConnection myConn = new MySqlConnection(myConnection);

                // MySqlDataAdapter sda = new MySqlDataAdapter(" SELECT * FROM studentcounseling.studentdata where RollNumber='" + this.rollno_txt.Text + "' ;", myConn);

                MySqlDataAdapter sda = new MySqlDataAdapter(" SELECT * FROM studentcounseling.studentdata where Rollnumber='" + this.rollno_txt.Text + "' ;", myConn);
                myConn.Open();

                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                myConn.Close();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "No Data");
                }

            }//if condition
            else
            {
                MessageBox.Show("please fill fields");
            }

        }

       /* private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataView Dv = new DataView(dt);
            Dv.RowFilter = String.Format("ROLLNO LIKE '%{0}'", rollno_txt.Text);
            dataGridView1.DataSource = Dv;

        }*/

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (rollno_txt.Text != "")
            {
                DataGridViewRow row = this.dataGridView1.RowTemplate;
                row.DefaultCellStyle.BackColor = Color.Bisque;
                row.Height = 40;
                row.MinimumHeight = 20;
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;



                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToResizeColumns = false;

                string myConnection = "datasource=localhost;port=3306;database=studentcounseling;username=root;password=2015";

                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlDataAdapter sda = new MySqlDataAdapter(" SELECT * FROM studentcounseling.previousdetails where RollNumber='" + this.rollno_txt.Text + "' ;", myConn);
                myConn.Open();

                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                myConn.Close();

               



                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "No Data");
                }

            }//if condition
            else
            {
                MessageBox.Show("please fill fields");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataView Dv = new DataView(dt);
            Dv.RowFilter = String.Format("ROLLNO LIKE '%{0}'", rollno_txt.Text);
            dataGridView1.DataSource = Dv;

          
        }

 private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 OpenFileDialog fd1 = new OpenFileDialog();
 private void profile_Click(object sender, EventArgs e)
 {
     if (rollno_txt.Text != "")
     {
         string myConnection = "datasource=localhost;port=3306;database=studentcounseling;username=root;password=2015";

         MySqlConnection myConn = new MySqlConnection(myConnection);

         MySqlCommand sda = new MySqlCommand(" SELECT * FROM studentcounseling.profiledata where RollNumber='" + this.rollno_txt.Text + "' ;", myConn);
        
         myConn.Open();

         MySqlDataReader dr1 = sda.ExecuteReader();

        
         if (dr1.Read())
         {
             
             label10.Text = dr1.GetValue(0).ToString();
             label11.Text = dr1.GetValue(1).ToString();
            label12 .Text = dr1.GetValue(2).ToString();
             label13.Text = dr1.GetValue(3).ToString();

            

            
             
                 byte[] imgg = (byte[])(dr1["image"]);
                 if (imgg == null)
                     pictureBox3.Image = null;
                 else
                 {

                     MemoryStream mstream = new MemoryStream(imgg);
                     pictureBox3.Image = System.Drawing.Image.FromStream(mstream);
                 }


             
       

         }
     }
     else
     {
         MessageBox.Show("Rollnumber must not be empty");
     }
 }

 

 

        

       

      
    }
}
