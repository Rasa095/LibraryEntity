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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            Context cntx=new Context();
            dataGridView1.DataSource = cntx.Students.ToList();
        }
        int i;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Context cntx = new Context();
                Student stud;
                stud = cntx.Students.Where(c => c.StudentId == i).FirstOrDefault();
                txtEnrollmentNo.Text = stud.EnrollmentNo;
                txtStudentContact.Text = stud.Contact.ToString();
                txtStudentDepartment.Text = stud.Departmnet;
                txtStudentEmail.Text = stud.StudentEmail;
                txtStudentName.Text = stud.StudentName;
                txtStudentSemester.Text = stud.Semester.ToString();
                panel2.Visible = true;
            }
           


        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Context cntx = new Context();
            Student stud;
            stud=cntx.Students.Where(s=>s.EnrollmentNo==txtEnrollmentNo.Text).FirstOrDefault();
            cntx.Students.Remove(stud);
            cntx.SaveChanges();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtEnrollmentNo.Text!="" && txtStudentContact.Text!=""&&txtStudentDepartment.Text!=""&&txtStudentEmail.Text!=""&&txtStudentName.Text!=""&& txtEnrollmentNo.Text != "")
            {
                if (MessageBox.Show("Are you sure for updating ?","Updating",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    
                    Student stud;
                    Context cntx = new Context();
                    stud = cntx.Students.Where(s => s.StudentId == i).FirstOrDefault();                                   
                    stud.Semester = Convert.ToInt32(txtStudentSemester.Text.ToString());
                    stud.StudentEmail = txtStudentEmail.Text;
                    stud.StudentName = txtStudentName.Text;
                    stud.Departmnet = txtStudentDepartment.Text;
                    stud.Contact = Convert.ToInt32(txtStudentContact.Text);
                    stud.EnrollmentNo = txtEnrollmentNo.Text;
                    cntx.SaveChanges();
                    dataGridView1.DataSource = cntx.Students.ToList();
                    
                   

                }
               
            }
           

        }
    }
}
