using System;
using System.Collections.Generic;


namespace RetailerAndTransactionSystem.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNo { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
        public string ProductType { get; set; } = null!;
        public double Balance { get; set; }
        public DateTime AccCreatedDate { get; set; }
        public string AccStatus { get; set; } = null!;
        public string BranchCode { get; set; } = null!;
        public string AccOpenBy { get; set; } = null!;
        public string SubProductType { get; set; } = null!;
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
