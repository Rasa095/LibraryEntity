using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test32.Model;

namespace test32
{
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            Context cntx = new Context();
            DatagridSee();

           
        }
        int i;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
           Context cntx= new Context();
            if (e.RowIndex !=-1)
            {
                 i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                var query = from issue in cntx.IssueBooks where issue.Id == i select issue;
                foreach (var book in query)
                {
                    txtBookName.Text = book.IssueBookName;
                    txtIssueDate.Text = book.IssuBookDate.ToString();
                }
                panel2.Visible = true;
            }
            
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Context cntx = new Context();
            Book bok;
            bok = cntx.Books.Where(b => b.BookName == txtBookName.Text).FirstOrDefault();
            if (bok != null)
            {
                bok.BookQuantity += 1;
            }             
            Student stud;
            stud=cntx.Students.Where(t=>t.EnrollmentNo == txtStudentEnrollment.Text).FirstOrDefault();
            if (stud != null)
            {
                stud.Issue_Book -= 1;
            }
            else MessageBox.Show("Enter valid Enrollment No");
            IssueBook iss;
            iss = cntx.IssueBooks.Where(s => s.Id == i).FirstOrDefault();
            iss.ReturnDateIssueBook = dateTimePicker1.Value;
            MessageBox.Show("Successfully returned book");
            cntx.SaveChanges();
            DatagridSee();

        }
        public void DatagridSee()
        {
            Context cntx=new Context();
            dataGridView1.DataSource = cntx.IssueBooks.Where(s => s.EnrollmentNo == txtStudentEnrollment.Text && s.ReturnDateIssueBook == null).ToList();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtBookName.Text = "";
            txtIssueDate.Text = "";
            panel2.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentEnrollment.Text = "";
            DatagridSee();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure for exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

       
    }
}
