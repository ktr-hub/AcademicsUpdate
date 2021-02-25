using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academics
{
    public static class InputValidation
    {
        public static bool validateString(string name)
        {
            bool isName = true;
            string pattern = "^[A-Za-z ]{3,30}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(name))
            {
                isName = false;
                MessageBox.Show("Enter correct text");
            }
            return isName;
        }
    }
}
