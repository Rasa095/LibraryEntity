using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test32.Validators
{
    internal class AddBookValidator
    {

        public AddBookValidator() { }

        public bool Validate(AddBook addBookForm)
        {
            if(string.IsNullOrEmpty(addBookForm.TextBoxName.Text))
            {
                return false;
            }
            return true;
        }
    }
}
