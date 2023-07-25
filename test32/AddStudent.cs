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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBoxStudentName.Text != "" && txtStudentEmail.Text != "" && txtSutdnetSemester.Text != "" && txtStudentContaxt.Text != "" && txtBoxEnrollmentNo.Text != "" && txtBoxDepartment.Text != "")
            {
                Context cntx = new Context();
                Student stud = new Student();
                stud.StudentName = txtBoxStudentName.Text;
                stud.StudentEmail = txtStudentEmail.Text;
                stud.Semester = Convert.ToInt32(txtSutdnetSemester.Text);
                stud.Contact = Convert.ToInt32(txtStudentContaxt.Text);
                stud.EnrollmentNo = txtBoxEnrollmentNo.Text;
                stud.Departmnet = txtBoxDepartment.Text;
                stud.Issue_Book = 0;
                cntx.Students.Add(stud);
                cntx.SaveChanges();
                MessageBox.Show("Add student Succesfuly");
            }
            else MessageBox.Show("Please Enter All Filds","ERORR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
           

           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           if(  MessageBox.Show("Are you sure to want exit ?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
           {
                this.Hide();
           }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBoxDepartment.Text = "";
            txtBoxEnrollmentNo.Text = "";
            txtBoxStudentName.Text = "";
            txtStudentContaxt.Text = "";
            txtStudentEmail.Text = "";
            txtSutdnetSemester.Text = "";
        }
    }
}
