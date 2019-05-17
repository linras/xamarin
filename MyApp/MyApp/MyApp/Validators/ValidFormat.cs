using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyApp.Validators
{
    class ValidFormat
    {
        public static bool Valid(string value, string pattern)
        {
            if (value == null)
            {
                return false;
            }
            else if (Regex.IsMatch(value, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
