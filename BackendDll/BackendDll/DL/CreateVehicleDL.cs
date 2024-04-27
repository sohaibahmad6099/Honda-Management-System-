using FormProject.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BackendDll
{
    public class CreateVehicleDL : ICreateVehicle
    {
        public static List<CreateVehicles> Vehicles = new List<CreateVehicles>();
        public void CreateVehicles(CreateVehicles vehicles, Users user)
        {
            int UserID = user.GetUserID();
            string Name = vehicles.GetName();
            string Brand = vehicles.GetBrand();
            int Quantity = vehicles.GetQuantity();
            float price = vehicles.GetPrice();
            Vehicles.Add(vehicles);

            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());
            string query = "insert into CreateVehicle values(@UserID,@Name,@Brand,@Quantity,@Price,@DateCreated)";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Brand", Brand);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<int> OrederID()
        {
            List<int> IDs = new List<int>();

            string connectionString = ConnectionString.GetConnectionString();
            string query = "SELECT OrderID FROM Orders";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("OrderID"));
                            IDs.Add(id);
                        }
                    }
                }

                con.Close();
            }
            return IDs;
        }

        public List<int> VehicleID()
        {
            List<int> IDs = new List<int>();

            string connectionString = ConnectionString.GetConnectionString();
            string query = "SELECT ID FROM CreateVehicle";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("ID"));
                            IDs.Add(id);
                        }
                    }
                }

                con.Close();
            }
            return IDs;
        }
        public void UpdatePrices(int num, float price, Users user)
        {
            int UserID = user.GetUserID();
            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());
            string query = "update CreateVehicle set UserID=@UserID, Price=@Price where ID=@ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", num);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AddvehicleinWishList(Users user, int ID)
        {
            int vehicleID = 0;
            string vehicleName = "";
            float vehiclePrice = 0;
            int UserID = user.GetUserID();
            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());
            con.Open();
            string query2 = "SELECT ID, Name, Price FROM CreateVehicle WHERE ID = @ID";

            SqlCommand cmd2 = new SqlCommand(query2, con);

            cmd2.Parameters.AddWithValue("@ID", ID);
            using (SqlDataReader reader = cmd2.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();

                    vehicleID = int.Parse(reader["ID"].ToString());
                    vehicleName = reader["Name"].ToString();
                    vehiclePrice = float.Parse(reader["Price"].ToString());
                }
            }
            cmd2.ExecuteNonQuery();
            con.Close();

            string query = "INSERT INTO WishList (UserID, VehicleID, VehicleName, VehiclePrice)\r\nSELECT @UserID, @VehicleID, @VehicleName, @VehiclePrice";
            //string query = "insert into WishList values(@UserID,@VehicleID,@VehicleName,@VehiclePrice where dbo.SignInSignUp.UserID=@UserID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
            cmd.Parameters.AddWithValue("@VehicleName", vehicleName);
            cmd.Parameters.AddWithValue("@VehiclePrice", vehiclePrice);


            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool PlaceOrder(Users user, int ID, int Quantity, string address)
        {
            int vehicleID = 0;
            float vehiclePrice = 0;
            int UserID = user.GetUserID();
            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());
            con.Open();
            string query2 = "SELECT ID, Price FROM CreateVehicle WHERE ID = @ID";

            SqlCommand cmd2 = new SqlCommand(query2, con);

            cmd2.Parameters.AddWithValue("@ID", ID);
            using (SqlDataReader reader = cmd2.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    vehicleID = int.Parse(reader["ID"].ToString());
                    vehiclePrice = float.Parse(reader["Price"].ToString());
                }
            }
            cmd2.ExecuteNonQuery();
            con.Close();


            string query = "INSERT INTO Orders (UserID, VehicleID, DateCreated, Price,Quantity,Address,Bill)\r\nSELECT @UserID, @VehicleID, @DateCreated, @Price,@Quantity,@Address,@Bill";
            //string query = "insert into WishList values(@UserID,@VehicleID,@VehicleName,@VehiclePrice where dbo.SignInSignUp.UserID=@UserID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
            cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
            cmd.Parameters.AddWithValue("@Price", vehiclePrice);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Bill", Quantity * vehiclePrice);


            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count > 0;
        }

        public List<int> WishlistID()
        {
            List<int> IDs = new List<int>();

            string connectionString = ConnectionString.GetConnectionString();
            string query = "SELECT ID FROM WishList";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("ID"));
                            IDs.Add(id);
                        }
                    }
                }

                con.Close();
            }
            return IDs;
        }
        public bool RemoveOrder(int ID)
        {
            string connectionString = ConnectionString.GetConnectionString();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Delete Orders where OrderID=@ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID",ID);
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count > 0;
        }
        public bool RemoveFromWishList(int ID)
        {
            string connectionString = ConnectionString.GetConnectionString();
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Delete WishList where ID=@ID";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", ID);
            int count = cmd.ExecuteNonQuery();
            con.Close();
            return count > 0;
        }
        public bool MakePayment(Users user,int ID,float Price)
        {
            int UserId = user.GetUserID();
            int vehicleID ;
            float vehiclePrice=0;
            string connectionString = ConnectionString.GetConnectionString();
            SqlConnection con = new SqlConnection( connectionString);
            string query = "select * from Orders where OrderID = @ID ";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@ID", ID);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    vehicleID = int.Parse(reader["OrderID"].ToString());
                    vehiclePrice = float.Parse(reader["Price"].ToString());
                }
            }
            cmd.ExecuteNonQuery();
            con.Close();

            string query2 = "INSERT INTO Payment (UserID, OrderID, Price, DatePayed,PayementMade)\r\nSELECT @UserID, @OrderID, @Price, @DatePayed,@PayementMade  where @Price<=@Payment" ; 
            con.Open();
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@UserID",UserId);
            cmd2.Parameters.AddWithValue("@OrderID",ID);
            cmd2.Parameters.AddWithValue("@Payment",Price);
            cmd2.Parameters.AddWithValue("@Price",vehiclePrice);
            cmd2.Parameters.AddWithValue("@DatePayed",DateTime.Now);
            cmd2.Parameters.AddWithValue("@PayementMade", 0);


            int count  = cmd2.ExecuteNonQuery();
            if(count > 0)
            {
                cmd2.Parameters.AddWithValue("@PayementMade",1);
                string query3 = "delete Orders where OrderID = @ID";
                SqlConnection con2 = new SqlConnection(ConnectionString.GetConnectionString());
                con2.Open();
                SqlCommand sql = new SqlCommand(query3 , con);
                sql.Parameters.AddWithValue("@ID",ID);
                sql.ExecuteNonQuery();
                con2.Close();
            }
            con.Close();
            return count > 0;
        }
    }
}
