using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNo { get; set; } 
        public string CustomerId { get; set; } 
        public string ProductType { get; set; }
        public double Balance { get; set; }
        public DateTime AccCreatedDate { get; set; }
        public string AccStatus { get; set; } 
        public string BranchCode { get; set; }
        public string AccOpenBy { get; set; } 
        public string SubProductType { get; set; } 
        public Account() { }
        public Account(int Id, string AccountNo, string CustomerId, string ProductType, double Balance, DateTime AccCreatedDate, string AccStatus, string BranchCode, string AccOpenBy, string SubProductType)
        {
            this.Id = Id;
            this.AccountNo = AccountNo;
            this.CustomerId = CustomerId;
            this.ProductType = ProductType;
            this.Balance =Balance;
            this.AccCreatedDate = AccCreatedDate;
            this.AccStatus = AccStatus;
            this.BranchCode = BranchCode;
            this.AccOpenBy = AccOpenBy;
            this.SubProductType = SubProductType;
        }
    }
}