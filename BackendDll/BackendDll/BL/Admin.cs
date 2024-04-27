using FormProject.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDll.BL
{
    public class Admin : Users
    {
        public Admin() { }
        public Admin(string role, string name, string email, string password, string num)
        {
            Role = role;
            UserName = name;
            Email = email;
            Password = password;
            PhoneNum = num;
        }
        public void SetRole(string role)
        {
            Role = role;
        }
    }
}
