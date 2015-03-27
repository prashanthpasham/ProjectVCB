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

namespace StudentCounseling
{
    public partial class Deleterecord : Form
    {
        public Deleterecord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (roll_txt.Text != "")
            {
                string myConnection = "datasource=localhost;port=3306;database=studentcounseling;username=root;password=2015";
                string Query = "delete from studentcounseling.studentdata where RollNumber='" + this.roll_txt.Text + "' ;";

                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlCommand cmd = new MySqlCommand(Query, myConn);
                MySqlDataReader myReader;
                try
                {
                    myConn.Open();
                    myReader = cmd.ExecuteReader();
                    MessageBox.Show("Your Requested Data Deleted Sucessfully");
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }//if condition
            else
            {
                MessageBox.Show("Please Enter Fields");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
