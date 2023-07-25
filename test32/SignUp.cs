using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test32
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

       

        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUserName.Text == "Username")
            {
                txtUserName.Text = "";
            }
           
        }

        private void btnClose_click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if(txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text !="" && txtUserName.Text!="Username"  && txtPassword.Text != "" && txtPassword.Text!="Password" && MessageBox.Show("Are you sure for creating this user?", "Creating", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                using (var ctx = new Context())
                {
                    Users user = new Users();
                    user.UserName = txtUserName.Text;
                    user.Password = txtPassword.Text;
                    ctx.Users.Add(user);
                    ctx.SaveChanges();

                }
                MessageBox.Show("Create user is Successfully");
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            else MessageBox.Show("Please Enter Username or Password");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }
    }
}
