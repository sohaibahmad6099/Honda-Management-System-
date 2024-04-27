using BackendDll.Interfeaces;
using FormProject.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace BackendDll
{
    public class CreatePartsDL: ICreateParts
    {
        public List<CreateParts> Parts = new List<CreateParts>();
        public void AddParts(CreateParts parts,Users user)
        {
            Parts.Add(parts);
            string Name = parts.GetName();
            string Brand = parts.GetBrand();
            int Qunatity = parts.GetQuantity();
            float Price = parts.GetPrice();
            int USerId = user.GetUserID();

            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());
            string query = "Insert into CreateParts VALUES(@UserID,@Name,@Brand,@Quantity,@Price)";
            con.Open();
            SqlCommand cm = new SqlCommand(query, con);
            cm.Parameters.AddWithValue("@Name", Name);
            cm.Parameters.AddWithValue("@Brand", Brand);
            cm.Parameters.AddWithValue("@Quantity", Qunatity);
            cm.Parameters.AddWithValue("@Price", Price);
            cm.Parameters.AddWithValue("@UserID", USerId);
            cm.ExecuteNonQuery();
            con.Close();
        }
        public bool UpdateDataofParts(int ID,CreateParts parts, Users user)
        {
            int id = ID;    
            string Name = parts.GetName();
            string Brand = parts.GetBrand();
            int Qunatity = parts.GetQuantity();
            float Price = parts.GetPrice();
            int USerId = user.GetUserID();

            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()); 
            string query = "UPDATE CreateParts SET UserID=@UserID, Name = @Name, Brand = @Brand, Quantity = @Quantity, Price = @Price WHERE ID = @ID";
            con.Open();
            SqlCommand cm = new SqlCommand(query, con);
            cm.Parameters.AddWithValue("@Name", Name);
            cm.Parameters.AddWithValue("@Brand", Brand);
            cm.Parameters.AddWithValue("@Quantity", Qunatity);
            cm.Parameters.AddWithValue("@Price", Price);
            cm.Parameters.AddWithValue("@ID", id);
            cm.Parameters.AddWithValue("@UserID", USerId);
            int data = cm.ExecuteNonQuery();
            con.Close();
            return data > 0;
        }
        public void LoadData()
        {
            Parts.Clear();
            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());
            con.Open();
            string query = "Select * from CreateParts";
            SqlCommand sql = new SqlCommand(query, con);
            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                string Brand = reader["Brand"].ToString();
                int Num = int.Parse(reader["Quantity"].ToString());
                float price = float.Parse(reader["Price"].ToString());
                //CreateParts parts = new CreateParts(reader["Name"].ToString(), reader["Brand"].ToString(), int.Parse(reader["Quantity"].ToString()), float.Parse(reader["Price"].ToString()));
                CreateParts parts = new CreateParts(name, Brand, Num, price);
                Parts.Add(parts);
            }
            con.Close();
        }
        public bool GetPart(string partName, int Quantity,Users user)
        {
            LoadData();
            for (int i = 0; i < Parts.Count; i++)
            {
                if (partName == Parts[i].GetName())
                {
                    int value = Parts[i].GetQuantity();
                    if (value - Quantity >= 0)
                    {
                        value = value - Quantity;
                        Parts[i].SetQuantity(value);
                        SetPartsQuantity(Quantity, partName,user);
                        return true;
                    }
                }
            }
            return false;
        }
        public List<CreateParts> GetDataOfParts()
        {
            Parts.Clear();
            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());
            con.Open();
            string query = "Select * from CreateParts";
            SqlCommand sql = new SqlCommand(query, con);
            SqlDataReader reader = sql.ExecuteReader();
            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                string Brand = reader["Brand"].ToString();
                int Num = int.Parse(reader["Quantity"].ToString());
                float price = float.Parse(reader["Price"].ToString());
                //CreateParts parts = new CreateParts(reader["Name"].ToString(), reader["Brand"].ToString(), int.Parse(reader["Quantity"].ToString()), float.Parse(reader["Price"].ToString()));
                CreateParts parts = new CreateParts(name, Brand, Num, price);
                Parts.Add(parts);
            }
            con.Close();
            return Parts;
        }
        public void SetPartsQuantity(int quantity,string name,Users user)
        {
           // int USerID = user.GetUserID();
            SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString());

            con.Open();
            string query = "update CreateParts set Quantity=@Quantity where Name=@Name";
            SqlCommand sql = new SqlCommand(@query, con);
            sql.Parameters.AddWithValue("@Quantity", quantity);
            sql.Parameters.AddWithValue("@Name", name);
            //sql.Parameters.AddWithValue("@UserID", USerID);
            sql.ExecuteNonQuery();
            con.Close();
        }
        public bool DeleteParts(int partID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString.GetConnectionString()))
                {
                    con.Open();
                    string query = "DELETE FROM CreateParts WHERE ID = @ID ";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@ID", partID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

    }
}
