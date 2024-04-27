using BackendDll.Interfeaces;
using FormProject.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendDll.BL;

namespace BackendDll
{
    public class CreateBikeDL : ICreateBike
    {
        public List<CreateVehicles> Vehicles = new List<CreateVehicles>();
        public void CreateBike(CreateVehicles vehicles)
        {
                string Name = vehicles.GetName();
                string Brand = vehicles.GetBrand();
                int Quantity = vehicles.GetQuantity();
                float price = vehicles.GetPrice();
                Vehicles.Add(vehicles);

                SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());
                string query = "insert into CreateVehicle values(@Name,@Brand,@Quantity,@Price,@DateCreated)";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Today);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Brand", Brand);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.ExecuteNonQuery();
                con.Close();
        }
    }
}
