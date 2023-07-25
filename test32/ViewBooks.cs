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
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }
        int i;
        private void ViewBooks_Load(object sender, EventArgs e)
        {
            var cnx = new Context();
            dataGridView1.DataSource = cnx.Books.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                var cnx = new Context();
                var book = cnx.Books.Where(u => u.BookId == i).SingleOrDefault();
                txtBoxName.Text = book.BookName;
                txtBoxAuthorName.Text = book.BookAuthor;
                txtBoxBookPrice.Text = book.BookPrice.ToString();
                txtBoxBookQuantity.Text = book.BookQuantity.ToString();
                dateTimePicker1.Text = book.BookPurchase.ToString();
                panel2.Visible = true;

            }

        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        Book book;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure for update?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (txtBoxName.Text != "" && txtBoxBookQuantity.Text != "" && txtBoxAuthorName.Text != "" && txtBoxBookPrice.Text != "")
                {
                    Context cntx = new Context();
                    book = cntx.Books.Where(u => u.BookId == i).SingleOrDefault();
                    book.BookName = txtBoxName.Text;
                    book.BookAuthor = txtBoxAuthorName.Text;
                    book.BookPrice = Convert.ToInt32(txtBoxBookPrice.Text);
                    book.BookQuantity = Convert.ToInt32(txtBoxBookQuantity.Text);
                    book.BookPurchase = dateTimePicker1.Value;
                    cntx.SaveChanges();
                    dataGridView1.DataSource = cntx.Books.ToList();
                }
                else MessageBox.Show("Please Enter All Filds if you want update Book","Erorr",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }




        }

        private void txtBooxSearchByName_TextChanged(object sender, EventArgs e)
        {
            Context cntx = new Context();
            dataGridView1.DataSource = cntx.Books.Where(c => c.BookName.Contains(txtBooxSearchByName.Text)).ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBooxSearchByName.Text = "";
            panel2.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Context cntx = new Context();
            Book bok;
            bok=cntx.Books.Where(c=>c.BookName==txtBoxName.Text).FirstOrDefault();

            if (bok != null)
            {
                if (MessageBox.Show("Are you sure for deleting this book ?", "Deleted", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                    cntx.Books.Remove(bok);
                    MessageBox.Show("Succesfully deleted book");
                    cntx.SaveChanges();
                }

            }
            else MessageBox.Show("Cant find this book");
        }
    }
}
