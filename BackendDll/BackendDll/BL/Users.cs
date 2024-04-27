using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.BL
{
    public class Users
    {
        protected string UserName;
        protected string Email;
        protected string Password;
        protected string PhoneNum;
        protected string Role;
        private int ID;
        public Users()
        { }
        public Users(string name,string email,string password,string PhoneNum,string Role)
        {
            UserName = name;
            Email = email;
            Password = password;
            this.PhoneNum = PhoneNum;
            this.Role = Role;
        }
        public Users(int ID,string name, string email, string password, string PhoneNum, string Role)
        {
            this.ID = ID;
            UserName = name;
            Email = email;
            Password = password;
            this.PhoneNum = PhoneNum;
            this.Role = Role;
        }
        public int GetUserID()
        {
            return ID;
        }

        public void SetUserName(string name)
        {
             UserName = name;
        }
        public void SetEmail(string email)
        {
             Email = email;
        }
        public void SetPassword(string Password)
        {
             this.Password = Password;
        }
        public string GetUserName()
        {
            return UserName;
        }
        public string GetEmail()
        {
            return Email;
        }
        public string GetPassword()
        {
            return Password;
        }
        public string GetPhoneNum()
        {
            return PhoneNum;
        }
        public string GetRole()
        {
            return Role;
        }
    }
}
