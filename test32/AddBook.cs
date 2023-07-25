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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxNameAuthor.Text = "";
            textBoxPrice.Text = "";
            textBoxQuantitz.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxNameAuthor.Text != "" && textBoxPrice.Text != "" && textBoxQuantitz.Text != "" && MessageBox.Show("Are you sure to add this book?", "Addeding", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var ctx = new Context())
                {
                    Book book = new Book() { BookName = textBoxName.Text, BookPrice = int.Parse(textBoxPrice.Text), BookAuthor = textBoxNameAuthor.Text, BookPurchase = dateTimePicker1.Value, BookQuantity = int.Parse(textBoxQuantitz.Text) };
                    ctx.Books.Add(book);
                    ctx.SaveChanges();
                    MessageBox.Show("Book add sucssesfully");
                }
            }
            else MessageBox.Show("Please enter all filds");
        }
    }
}
