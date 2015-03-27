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
using System.Data.SqlClient;
using System.Configuration;


namespace StudentCounseling
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
         

        private void button1_Click(object sender, EventArgs e)
        {
            if(name_txt.Text!="" && rollno_txt.Text!="" && year_txt.Text!="" && branch_txt.Text!="" && attendence_txt.Text!="" && aggregate_txt.Text!=""){

            string myConnection = "datasource=localhost;port=3306;database=studentcounseling;username=root;password=2015";
           string Query = "insert into studentcounseling.studentdata (Name,RollNumber,Year,Attendencepercentage,Aggegratepercentage,Branch) values('" + this.name_txt.Text + "','" + this.rollno_txt.Text + "','" + this.year_txt.Text + "','" + this.attendence_txt.Text + "','" + this.aggregate_txt.Text + "','"+this.branch_txt.Text + "')";
        
            MySqlConnection myConn = new MySqlConnection(myConnection);
           
           MySqlCommand cmd = new MySqlCommand(Query,myConn);
           MySqlDataReader myReader;
           try
           {
               myConn.Open();
               myReader = cmd.ExecuteReader();
               MessageBox.Show("Data Sucessfully saved");
               while (myReader.Read())
               {

               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
            }
            else{
                MessageBox.Show("please fill Fields");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if(name_txt.Text!=""||rollno_txt.Text!=""||year_txt.Text!=""||attendence_txt.Text!=""||aggregate_txt.Text!=""){
            string myConnection = "datasource=localhost;port=3306;database=studentcounseling;username=root;password=2015";
            string Query = "update studentcounseling.studentdata set Name='" + this.name_txt.Text + "',RollNumber='" + this.rollno_txt.Text + "',Year='" + this.year_txt.Text + "',Attendencepercentage='" + this.attendence_txt.Text + "',Aggegratepercentage='" + this.aggregate_txt.Text + "',Branch='" +this.branch_txt.Text+"' where RollNumber = '" +this.rollno_txt.Text +"' ;";

            MySqlConnection myConn = new MySqlConnection(myConnection);

            MySqlCommand cmd = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("updated Data Sucessfully");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }//if condition
            else{
                MessageBox.Show("please enter Fields");
            }
            }
           
        

        private void button3_Click(object sender, EventArgs e)
        {

            //reset the fields
            CleartextBoxes2();
        }
        public void CleartextBoxes2()
        {

            foreach (Control Cleartext in this.Controls)
            {

                if (Cleartext is TextBox)
                {

                    ((TextBox)Cleartext).Text = string.Empty;

                }

            }

        }
    }


        }

       
    

