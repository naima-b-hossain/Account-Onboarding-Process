using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class AccTransactionInfo
    {
        public int Id { get; set; }

        public string TransactionId { get; set; }

        public string AccountNo { get; set; }

        public string TransactionType { get; set; }

        public DateTime TransactionDate { get; set; }

        public double TranAmmount { get; set; }

        public string Narration { get; set; }

        public string TransactionTo { get; set; }

        public AccTransactionInfo() { }

        public AccTransactionInfo(int Id, string TransactionId, string AccountNo, string TransactionType, DateTime TransactionDate, double TranAmmount, string Narration, string TransactionTo)
        {
            this.Id = Id;
            this.TransactionId = TransactionId;
            this.AccountNo = AccountNo;
            this.TransactionType = TransactionType;
            this.TransactionDate =TransactionDate;
            this.TranAmmount = TranAmmount;
            this.Narration = Narration;
            this.TransactionTo = TransactionTo;

        }
    }
}