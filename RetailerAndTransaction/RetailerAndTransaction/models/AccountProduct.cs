using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class AccountProduct
    {
        public int Id { get; set; }

        public string ProductType { get; set; }

        public string ProductName { get; set; }


        //public AccountProduct() { }


        public AccountProduct(int Id, string ProductType, string ProductName)
        {
            this.Id = Id;
            this.ProductType = ProductType;
            this.ProductName = ProductName;



        }
    }
}