using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendDll
{
    public class CreateVehicles : CreateParts
    {
        private int Engine;
        private int Frame;
        private int Tyre;
        private int Light;
        public CreateVehicles()
        { }
        public CreateVehicles(int engine, int frame, int tyre, int light,string Name,string Brand, int Quantity, float Price) : base(Name,Brand,Quantity,Price)
        {
            Engine = engine;
            Frame = frame;
            Tyre = tyre;
            Light = light;
        }
        public CreateVehicles(int engine, int frame, int tyre, int light, string Name, string Brand, int Quantity, float Price,int ID,DateTime dateCreated) : base(Name, Brand, Quantity, Price,  ID,  dateCreated)
        {
            Engine = engine;
            Frame = frame;
            Tyre = tyre;
            Light = light;
        }

    }
}
