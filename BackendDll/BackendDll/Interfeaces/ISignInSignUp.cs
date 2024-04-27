using FormProject.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDll.Interfeaces
{
    public interface ISignInSignUp
    {
        void AddUser(Users User);
        bool SignUp(Users user);
        bool UpdateUserData(string Name, string Password, string PhoneNum, string Email, string NewName, string NewPassword);
        bool UpdatePersonalData(int Id, string UserName, string Password, string Email, string PhoneNum);
        Users ReadSignInUser(Users user);

    }
}
