using System;



namespace RetailerAndTransactionSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductType { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public Product() { }
        public Product(int Id, string ProductType, string ProductName)
        {
            this.Id = Id;
            this.ProductType = ProductType;
            this.ProductName = ProductName;
        }
    }
}
