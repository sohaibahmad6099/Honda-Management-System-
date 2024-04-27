using FormProject.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDll.BL
{
    public class Employee : Users
    {
        public Employee() { }
        public Employee(string role, string name, string email, string password, string num)
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
