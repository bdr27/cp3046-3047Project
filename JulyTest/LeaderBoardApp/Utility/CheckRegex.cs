using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeaderBoardApp.Utility
{
    public static class CheckRegex
    {
        public static bool IsValidName(string name)
        {
            if (Regex.Match(name, @"^[a-zA-Z]+$").Success)
            {
                return true;
            }
            return false;
        }

        public static bool IsValidAge(string age)
        {
            if (Regex.Match(age, @"^[0-9]+$").Success)
            {
                return true;
            }
            return false;
        }

        public static bool IsValidNumber(string number)
        {
            if (Regex.Match(number, @"^[0-9]+$").Success)
            {
                return true;
            }
            return false;
        }
    }
}
