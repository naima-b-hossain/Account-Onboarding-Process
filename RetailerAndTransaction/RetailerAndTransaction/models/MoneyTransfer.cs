using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class MoneyTransfer
    {
        public string SenderAccountNo { get; set; } 
        public string ReceiverAccountNo { get; set; }
        public double TransferAmount { get; set; }
        public string Reference { get; set; }
        public MoneyTransfer() { }
        public MoneyTransfer(string SenderAccountNo, string ReceiverAccountNo, double TransferAmount, string Reference)
        {
            this.SenderAccountNo = SenderAccountNo;
            this.ReceiverAccountNo = ReceiverAccountNo;
            this.TransferAmount = TransferAmount;
            this.Reference = Reference;
        }
    }
}