using System;

namespace BackendDll
{
    public class CreateParts
    {
        protected string Name;
        protected string Brand;
        protected int Quantity;
        protected float Price;
        protected int UserID;
        protected int ID;
        protected DateTime dateCreated;
        public CreateParts()
        { }
        public CreateParts(string Name, string Brand, int Qunatity, float Price,int ID,DateTime dateCreated)
        {
            this.Name = Name;
            this.Brand = Brand;
            this.Quantity = Qunatity;
            this.Price = Price;
            this.ID = ID;
            this.dateCreated = dateCreated;
        }
        public CreateParts(string Name, string Brand, int Qunatity, float Price)
        {
            this.Name = Name;
            this.Brand = Brand;
            this.Quantity = Qunatity;
            this.Price = Price;
        }
        public CreateParts(int UserID,string Name, string Brand, int Qunatity, float Price)
        {
            this.UserID = UserID;
            this.Name = Name;
            this.Brand = Brand;
            this.Quantity = Qunatity;
            this.Price = Price;
        }
        public CreateParts(int UserID, string Name, string Brand, int Qunatity, float Price,int ID,DateTime dateCreated)
        {
            this.UserID = UserID;
            this.Name = Name;
            this.Brand = Brand;
            this.Quantity = Qunatity;
            this.Price = Price;
            this.ID = ID;
            this.dateCreated = dateCreated;
        }
        public int GetUserID()
        {
            return UserID;
        }
        public void SetName(string Name)
        {
            this.Name=Name;
        }
        public void SetBrand(string Brand)
        {
            this.Brand = Brand;
        }
        public void SetQuantity(int Qunatity)
        {
            this.Quantity = Qunatity;
        }
        public void SetPrice(float Price)
        {
            this.Price = Price;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetBrand()
        {
            return Brand;
        }
        public int GetQuantity()
        {
            return Quantity;
        }
        public float GetPrice()
        {
            return Price;
        }
        public int GetID()
        {
            return ID;
        }
        public DateTime GetDateTime()
        {
            return dateCreated;
        }
    }
}
