namespace RetailerAndTransactionSystem.Models
{
    public class MoneyTransferOwnAccount
    {
        public string AccountNo { get; set; }
        public double TransferAmount { get; set; }
        public string TransferType { get; set; }
        public MoneyTransferOwnAccount() { }
        public MoneyTransferOwnAccount(string AccountNo, double TransferAmount, string TransferType)
        {
            this.AccountNo = AccountNo;  
            this.TransferAmount = TransferAmount;
            this.TransferType = TransferType;   
        }
    }
}
