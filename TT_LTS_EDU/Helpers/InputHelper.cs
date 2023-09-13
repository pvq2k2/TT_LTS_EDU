using System.Globalization;
using System.Text.RegularExpressions;

namespace TT_LTS_EDU.Helpers
{
    public class InputHelper
    {
        public static bool CheckLengthOfCharacters(string fullName)
        {
            return fullName.Length > 20;
        }
        public static bool CheckWordCount(string fullName)
        {
            return fullName.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length < 2;
        }
        public static string NormalizeName(string fullName)
        {
            fullName = fullName.Trim();

            fullName = Regex.Replace(fullName, @"\p{P}", " ").Trim();
            fullName = Regex.Replace(fullName, @"\s+", " ");

            TextInfo textInfo = new CultureInfo("vi-VN", false).TextInfo;
            return textInfo.ToTitleCase(fullName.ToLower());
        }

        public static bool RegexUserName(string userName)
        {
            string pattern = @"^[a-zA-Z0-9_]+$";

            return Regex.IsMatch(userName, pattern);
        }

        public static bool RegexPassword(string password)
        {
            string pattern = @"^(?=.*\d)(?=.*[\W_])[A-Za-z\d\W_]+$";

            return Regex.IsMatch(password, pattern);
        }

        public static bool RegexEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, pattern);
        }

        public static bool RegexPhoneNumber(string phoneNumber)
        {
            string pattern = @"^(?:\+84|0)(?:3[2-9]|5[689]|7[06-9]|8[1-9]|9[0-9])[0-9]{7}$";

            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
