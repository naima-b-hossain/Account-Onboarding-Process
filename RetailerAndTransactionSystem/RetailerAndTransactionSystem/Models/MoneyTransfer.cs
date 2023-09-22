namespace RetailerAndTransactionSystem.Models
{
    public class MoneyTransfer
    {
        public string SenderAccountNo { get; set; } = null!;
        public string ReceiverAccountNo { get; set; } = null!;
        public double TransferAmount { get; set; }
        public string Reference { get; set; } = null!;
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
