using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test32.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public DateTime BookPurchase { get; set; }
        public int BookPrice { get; set; }   
        public int BookQuantity {get;set; }
    }
}
