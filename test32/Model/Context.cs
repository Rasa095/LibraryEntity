using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using test32.Model;

namespace test32
{
    public class Context : DbContext
    {
       
        public DbSet<Users> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }   
        public DbSet<IssueBook> IssueBooks { get; set; }
    }
}
  

