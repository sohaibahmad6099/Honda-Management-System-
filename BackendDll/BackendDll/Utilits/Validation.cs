using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.RegularExpressions;

namespace BackendDll
{
    public class Validation
    {
        public bool ContactCheck(string contact)
        {
            // Check length of contact number
            if (contact.Length < 4 || contact.Length > 15)
            {
                return false;
            }
            // Check if contact contains only numeric characters
            foreach (char c in contact)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public bool PasswordCheck(string password)
        {
            // Check length of password
            if (password.Length < 6 || password.Length > 20)
            {
                return false;
            }
            // Check if password contains at least one letter and one digit
            if (!password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                return false;
            }
            // Check if password contains spaces
            if (password.Any(char.IsWhiteSpace))
            {
                return false;
            }
            return true;
        }
        public bool NameCheck(string text)
        {
            // Check length of name
            if (text.Length > 50)
            {
                return false;
            }
            // Check if name contains only alphabets
            foreach (char c in text)
            {
                if ((c < 'a' || c > 'z') && (c < 'A' || c > 'Z') && c != ' ')
                {
                    return false;
                }
            }
            // Check if the first letter of name is capital
            if (text[0] < 'A' || text[0] > 'Z')
            {
                return false;
            }
            return true;
        }

        //    }
        //    string c;
        public bool CheckNumber(string text)
        {
            int a;
            if (int.TryParse(text, out a))
            {
                return true; // Return true only if parsing is successful
            }
            else
            {
                return false; // Otherwise, return false
            }
        }
        public bool CheckFloat(string text)
        {
            float b;
            if (float.TryParse(text, out b) && text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //    public bool CheckString(string text)
        //    {
        //        int a;
        //        float b;
        //        if (!int.TryParse(text, out a) && !float.TryParse(text, out b) && text != "")
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    public bool checkStringForGarbage(string text)
        //    {
        //        bool a = true; ;
        //        for (int i = 0; i <= text.Length; i++)
        //        {
        //            if (text[i] == ' ' || text[i] == '\t' || text[i] == '\n' || text[i] == '=' || text[i] == '+' || text[i] == '_' || text[i] == ';' || text[i] == ',' ||
        //                text[i] == '.' || text[i] == '/' || text[i] == '\\' || text[i] == '<' || text[i] == '>' || text[i] == '(' || text[i] == ')' || text[i] == '{' ||
        //                text[i] == '}' || text[i] == '[' || text[i] == ']' || text[i] == ':')
        //            {
        //                a = false;
        //            }
        //        }
        //        return a;
        //    }
        //    public bool CheckStringForemail(string text)
        //    {
        //        int one = 0;
        //        bool a;
        //        a = false;
        //        for (int i = 0; i <= text.Length; i++)
        //        {
        //            if (text[i] == '@')
        //            {
        //                one++;

        //            }
        //            else if (text[i] == '.')
        //            {
        //                one++;
        //            }
        //        }
        //        if (one == 2)
        //        {
        //            a = true;
        //        }
        //        return a;


    }
}

