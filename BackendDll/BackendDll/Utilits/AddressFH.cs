using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDll.Utilits
{
    public  class AddressFH
    {
        private static string ConnectionOfFile = "D:\\Semester 2 Lectures\\Programming Day\\BackendDll\\BackendDll\\bin\\Debug\\CreateParts.txt";
        public AddressFH() 
        { }
        public static string SignInSignUpFH()
        {
            return ConnectionOfFile;
        }
    }
}
