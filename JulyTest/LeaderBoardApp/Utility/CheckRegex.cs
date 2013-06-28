using System.Text.RegularExpressions;

namespace LeaderBoardApp.Utility
{
    public static class CheckRegex
    {
        public static bool IsValidAge(string age)
        {
            return Regex.Match(age, @"^[0-9]+$").Success;
        }

        public static bool IsValidGuardian(string guardian)
        {
            return Regex.Match(guardian, @"^[a-zA-Z\-]+ [a-zA-Z\-]+$").Success || Regex.Match(guardian, @"^[a-zA-Z\-]+$").Success;
        }
        public static bool IsValidName(string name)
        {
            return Regex.Match(name, @"^[a-zA-Z\-]+$").Success;
        }

        public static bool IsValidContact(string number)
        {
            return Regex.Match(number, @"^([0-9]|[0-9] |[0-9]-)+$").Success;
        }

        public static bool IsValidTeamName(string teamName)
        {
            return Regex.Match(teamName, @"^[a-zA-Z\-\ ]+$").Success;
        }
    }
}
