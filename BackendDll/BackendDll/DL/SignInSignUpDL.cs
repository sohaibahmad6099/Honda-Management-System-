using BackendDll.Interfeaces;
using FormProject.BL;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace BackendDll
{
    public class SignInSignUpDL: ISignInSignUp
    {
        public static List<Users> users = new List<Users>();
        public void AddUser(Users User)
        {
            string UserName = User.GetUserName();
            string Password = User.GetPassword();
            string Role = User.GetRole();
            string PhoneNum = User.GetPhoneNum();
            string Email = User.GetEmail();
            users.Add(User);

            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());
            string query = "Insert into SignInSignUp VALUES(@UserName,@Password,@Role,@PhoneNum,@Email)";
            con.Open();
            SqlCommand cm = new SqlCommand(query, con);
            cm.Parameters.AddWithValue("@UserName", UserName);
            cm.Parameters.AddWithValue("@Password", Password);
            cm.Parameters.AddWithValue("@Role", Role);
            cm.Parameters.AddWithValue("@PhoneNum", PhoneNum);
            cm.Parameters.AddWithValue("@Email", Email);
            cm.ExecuteNonQuery();
            con.Close();
        }
        public bool SignUp(Users user)
        {
            bool State;;
            string userName = user.GetUserName();
            string password = user.GetPassword();
            string role = user.GetRole();

            string Query = "SELECT CASE WHEN COUNT(*) > 0 THEN 'true' ELSE 'false' END AS has_data FROM SignInSignUp WHERE UserName = @UserName AND Password = @Password AND Role = @Role;";

            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();
                using (SqlCommand sql = new SqlCommand(Query, con))
                {
                    sql.Parameters.AddWithValue("@UserName", userName);
                    sql.Parameters.AddWithValue("@Password", password);
                    sql.Parameters.AddWithValue("@Role", role);
                    
                    

                    object result = sql.ExecuteScalar();

                    string resultString = result.ToString();
                    if (resultString == "true")
                    {
                        State = true;
                    }
                    else
                    {
                        State = false;
                    }
                }
                con.Close();
            }
            return State;

        }
        public bool UpdateUserData(string Name,string Password,string PhoneNum,string Email,string NewName,string NewPassword)
        {
            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());
            string query = "UPDATE SignInSignUp SET UserName = @NewName, Password = @NewPassword, PhoneNum = @PhoneNum, Email = @Email WHERE UserName = @Name AND Password = @Password";

            con.Open();

            SqlCommand cm = new SqlCommand(query, con);
            cm.Parameters.AddWithValue("@NewName", NewName);
            cm.Parameters.AddWithValue("@NewPassword", NewPassword);
            cm.Parameters.AddWithValue("@PhoneNum", PhoneNum);
            cm.Parameters.AddWithValue("@Email", Email);
            cm.Parameters.AddWithValue("@Name", Name);
            cm.Parameters.AddWithValue("@Password", Password);

            int count = cm.ExecuteNonQuery();

            con.Close();

            bool success = (count > 0); 

            return success;
        }
        public bool UpdatePersonalData(int Id,string UserName ,string Password,string Email,string PhoneNum)
        {
            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());

            con.Open();
            string query = "Update SignInSignUp set UserName=@UserName,Password=@Password,Email=@Email,PhoneNum=@PhoneNum where ID=@ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@PhoneNum", PhoneNum);
            cmd.Parameters.AddWithValue("@ID", Id);
            int count = cmd.ExecuteNonQuery();
            con.Close();

            return count>0;
        }
        public Users ReadSignInUser(Users user)
        {
            string userName = user.GetUserName();
            string password = user.GetPassword();
            string role = user.GetRole();
            Users users = null;

            string query = "SELECT ID, UserName, Password, Role, PhoneNum, Email FROM SignInSignUp WHERE UserName = @UserName AND Password = @Password AND Role = @Role";

            using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Role", role);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userID = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string userPassword = reader.GetString(2);
                            string userRole = reader.GetString(3);
                            string phoneNum = reader.GetString(4);
                            string email = reader.GetString(5);

                            users = new Users(userID, name, email, userPassword, phoneNum, userRole);
                        }
                    }
                }
            }
            return users;
            }
    }
}
