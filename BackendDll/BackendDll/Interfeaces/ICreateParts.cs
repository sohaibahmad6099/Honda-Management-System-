using FormProject.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDll.Interfeaces
{
    public interface ICreateParts
    {
        void AddParts(CreateParts parts,Users users);
        void LoadData();
        bool GetPart(string partName, int Quantity,Users user);
        bool UpdateDataofParts(int id,CreateParts parts,Users users);
        bool DeleteParts(int partID);
        List<CreateParts> GetDataOfParts();
        void SetPartsQuantity(int quantity, string name,Users user);
    }
}
