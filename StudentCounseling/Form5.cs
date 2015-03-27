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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;


namespace StudentCounseling
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            string FileName = string.Format(@"{0}.pdf", Guid.NewGuid());
        }

        DataTable dt;
       
        private void showdata_Click(object sender, EventArgs e)
        {
            if (branch_txt.Text!="" && year_txt.Text!="")
            {
                DataGridViewRow row = this.dataGridView2.RowTemplate;
                row.DefaultCellStyle.BackColor = Color.Bisque;
                row.Height = 40;
                row.MinimumHeight = 20;
                dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;



                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.AllowUserToResizeColumns = false;

                string myConnection = "datasource=localhost;port=3306;database=studentcounseling;username=root;password=2015";

                MySqlConnection myConn = new MySqlConnection(myConnection);

                MySqlDataAdapter sda = new MySqlDataAdapter(" SELECT * FROM studentcounseling.studentdata where Branch = '" + this.branch_txt.Text + "' and Year = '" + this.year_txt.Text + "' ;", myConn);
                
                myConn.Open();

                dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataView Ds = new DataView(dt);
            Ds.RowFilter = String.Format("BRANCH LIKE '%{0}'", branch_txt.Text);
            dataGridView2.DataSource = Ds;
        }

       
      

        private void button3_Click(object sender, EventArgs e)
        {
           

            PdfPTable pdfTable = new PdfPTable(dataGridView2.ColumnCount);
            pdfTable.DefaultCell.Padding = 4;
            pdfTable.WidthPercentage = 90;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No data available.", "No Data");
            }

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
           // using (FileStream stream = new FileStream(folderPath + "DataGridViewResul.pdf",FileMode.Create))
           // {
                

               // Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);

                //PdfWriter.GetInstance(pdfDoc, stream);

                //pdfDoc.Open();
                //pdfDoc.Add(pdfTable);
               // pdfDoc.Close();
                //stream.Close();
           // }
            Document document = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
            var filename = "Datainpdf" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
            var output = new FileStream(folderPath + filename, FileMode.Create);
             PdfWriter.GetInstance(document, output);
            document.Open();
            document.Add(pdfTable);
            document.Close();
            output.Close();


           MessageBox.Show("Your PDF File is generated Sucessfully.pdf file located at C:\\PDFS folder");
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //insert or update record
            Form4 sg = new Form4();
            sg.Show();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           //delete record
            Deleterecord jh = new Deleterecord();
            jh.Show();
        }

        private void profile_Click(object sender, EventArgs e)
        {
            Profile li = new Profile();
            li.Show();
        }

       
       
      

       
    }
}
