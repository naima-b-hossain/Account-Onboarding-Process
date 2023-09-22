namespace RetailerAndTransactionSystem.Models
{
    public class Division
    {
        public int Id { get; set; }

        public string DivisionCode { get; set; } = null!;

        public string DivisionName { get; set; } = null!;


        public Division(int Id, string DivisionCode, string DivisionName)
        {
            this.Id = Id;
            this.DivisionCode = DivisionCode;
            this.DivisionName = DivisionName;
           
        }
    }
}
