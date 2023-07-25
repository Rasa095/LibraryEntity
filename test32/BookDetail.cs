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
    public partial class BookDetail : Form
    {
        public BookDetail()
        {
            InitializeComponent();
        }

        private void BookDetail_Load(object sender, EventArgs e)
        {
            Context cntx=new Context();
            dataGridView2.DataSource = cntx.IssueBooks.Where(c=>c.ReturnDateIssueBook!=null).ToList();
            dataGridView1.DataSource=cntx.IssueBooks.Where(c=>c.ReturnDateIssueBook==null).ToList();
        }
    }
}
