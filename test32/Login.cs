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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var cnx=new Context())
            {
                var user = cnx.Users.SingleOrDefault(us => us.UserName == txtUserName.Text);
                if (user != null)
                {
                    if (user.Password == txtPassword.Text)
                    {
                        MessageBox.Show("Login Sucssesfully");
                    }
                    else MessageBox.Show("Enter corect password");
                    Dashboradcs dsh = new Dashboradcs();
                    dsh.Show();
                }
                else MessageBox.Show("Enter valid Username");
                
              
            }
        }

       

        private void label1_Click(object sender, EventArgs e)
        {
            SignUp sig = new SignUp();
            sig.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp sig = new SignUp();
            sig.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtUserName.Text == "Username")
            {
                txtUserName.Text = "";
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
            }
        }

       
    }
}
