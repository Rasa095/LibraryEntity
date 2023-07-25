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
using test32.Validators;

namespace test32
{
    public partial class AddBook : Form
    {
        private AddBookValidator validator;
        public AddBook()
        {
            InitializeComponent();
            validator = new AddBookValidator();
            button1.Enabled = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            TextBoxName.Text = string.Empty;
            TextBoxNameAuthor.Text = "";
            TextBoxPrice.Text = "";
            TextBoxQuantitz.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validator.Validate(this))
            {
                MessageBox.Show("Please enter all filds");
                return;
            }


            using (var ctx = new Context())
            {
                Book book = new Book()
                {
                    BookName = TextBoxName.Text,
                    BookPrice = int.Parse(TextBoxPrice.Text),
                    BookAuthor = TextBoxNameAuthor.Text,
                    BookPurchase = dateTimePicker1.Value,
                    BookQuantity = int.Parse(TextBoxQuantitz.Text)
                };

                ctx.Books.Add(book);
                ctx.SaveChanges();
                MessageBox.Show("Book add sucssesfully");
            }

        }

        private void textBoxNameAuthor_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                errorProvider1.SetError(textBoxName, "Name should not be left blank!");
            }

        }

        private void IsSaveEnabled(object sender, EventArgs e)
        {
            button1.Enabled = validator.Validate(this);
        }
    }
}
