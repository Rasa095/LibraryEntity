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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

      

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            Context cntx = new Context();
           
            var stud = cntx.Students.Where(c => c.EnrollmentNo == txtEnrollmentNo.Text).FirstOrDefault();
            if (txtEnrollmentNo.Text != "")
            {
                if (stud != null)
                {
                    txtStudentName.Text = stud.StudentName;
                    txtStudentContact.Text = stud.Contact.ToString();
                    txtStudentDepartment.Text = stud.Departmnet;
                    txtStudentEmail.Text = stud.StudentEmail;
                    txtStudentSemenster.Text = stud.Semester.ToString();
                    txtStudentEnrollmentNo.Text = stud.EnrollmentNo;
                }
                else MessageBox.Show("Incorrect Enrollment No,Please enter valid Enrollment No");
            }
            else MessageBox.Show("Please Enter Enrollment No");
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnrollmentNo.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
            }
           
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text != "" && txtBookName.Text != "")
            {
                if (MessageBox.Show("Are you sure you want issue this book?", "Issue", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Context cntx = new Context();
                    Book bok;
                    bok = cntx.Books.Where(b => b.BookName == txtBookName.Text).FirstOrDefault();
                    if (bok != null)
                    {
                        if (bok.BookQuantity > 0)
                        {
                            Student stud;
                            stud = cntx.Students.Where(s => s.StudentName == txtStudentName.Text).FirstOrDefault();
                            if (stud.Issue_Book < 2)
                            {
                                IssueBook newIssue = new IssueBook();
                                newIssue.StudentName = txtStudentName.Text;
                                newIssue.IssueBookName = txtBookName.Text;
                                newIssue.Semester = Convert.ToInt32(txtStudentSemenster.Text);
                                newIssue.IssuBookDate = dateTimePicker1.Value;
                                newIssue.StudentContact = Convert.ToInt32(txtStudentContact.Text);
                                newIssue.StudentDepartment = txtStudentDepartment.Text;
                                newIssue.StudentEmail = txtStudentEmail.Text;
                                newIssue.EnrollmentNo = txtEnrollmentNo.Text;
                                cntx.IssueBooks.Add(newIssue);

                                bok.BookQuantity -= 1;
                                stud.Issue_Book += 1;
                                cntx.SaveChanges();
                                MessageBox.Show("Issue Succsesfully");
                            }
                            else MessageBox.Show("Max issue per student is 3 books,please return book then issue another");
                        }
                        else MessageBox.Show("This book is not valible");
                    }
                    else MessageBox.Show("This book are not in state");
                        

                }


            }
            else MessageBox.Show("Please enter all filds");
           

        }

       
    }
}
