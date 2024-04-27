using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDll
{
    public  class ConnectionString
    {
        private static string conn = "Data Source=MSI;Initial Catalog=HonMS;Integrated Security=True";
        public static string GetConnectionString()
        {
            return conn;
        }
    }
}
