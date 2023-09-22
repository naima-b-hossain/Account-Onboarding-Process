using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class SubProduct
    {
        public int Id { get; set; }
        public string SubProductType { get; set; } 
        public string ProductType { get; set; } 
        public string SubProductName { get; set; } 
        public SubProduct() { }
        public SubProduct(int Id, string SubProductType, string ProductType, string SubProductName)
        {
            this.Id = Id;
            this.SubProductType = SubProductType;
            this.ProductType = ProductType;
            this.SubProductName = SubProductName;
        }
    }
}