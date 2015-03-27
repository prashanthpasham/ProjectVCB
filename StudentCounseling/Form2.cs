using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;



namespace StudentCounseling
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            password_txt.PasswordChar = '$';
            password_txt.MaxLength = 10;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && password_txt.Text != "")
            {
                try
                {
                    string myConnection = "datasource=localhost;port=3306;database=studentcounseling;username=root;password=2015";

                    MySqlConnection myConn = new MySqlConnection(myConnection);
                    MySqlCommand SelectCommand = new MySqlCommand(" SELECT * FROM studentcounseling.registration where username='" + this.textBox1.Text + "' and Password='" + this.password_txt.Text + "' ;", myConn);
                    MySqlDataReader myReader;
                    myConn.Open();
                    myReader = SelectCommand.ExecuteReader();
                    int count = 0;
                    while (myReader.Read())
                    {
                        count = count + 1;

                    }
                    if (count == 1)
                    {
                        MessageBox.Show("Your are Loggedin Sucessfully");
                        this.Hide();
                        Form5 gh = new Form5();
                        gh.Show();

                    }
                    else if (count > 1)
                    {
                        MessageBox.Show("Duplicate username and password access denied");
                    }
                    else
                    {

                        MessageBox.Show("Invalid username and password");
                        myConn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//if condition
            else
            {
                MessageBox.Show("Fields Should not be Empty");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
             Homepage f2 = new Homepage();
            f2.Show();
            
        }

       
    }
}
