using FormProject.BL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDll
{
    public interface ICreateVehicle
    {
       void UpdatePrices(int num, float price,Users user);
       void CreateVehicles(CreateVehicles vehicles, Users user);
       List<int> VehicleID();
       List<int> OrederID();
        bool RemoveOrder(int ID);
        bool RemoveFromWishList(int ID);
        List<int> WishlistID();
        void AddvehicleinWishList(Users user, int ID);
        bool PlaceOrder(Users user, int ID, int Quantity, string address);
        bool MakePayment(Users user, int ID, float Price);
    }
}
