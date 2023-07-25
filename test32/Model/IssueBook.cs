using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test32.Model
{
    public class IssueBook
    {
        public int Id { get; set; } 
        public string StudentName { get; set; }
       
        public string StudentEmail { get; set;}
        public string StudentDepartment { get; set; }

        public int StudentContact { get; set; }
        public int Semester { get; set; }
        public string IssueBookName { get; set; }
        public DateTime IssuBookDate { get; set; }
        public DateTime? ReturnDateIssueBook { get; set; }
        public string EnrollmentNo { get; set; }




    }
}
