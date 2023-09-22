namespace RetailerAndTransactionSystem.Models
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictCode { get; set; } = null!;
        public string DivisionCode { get; set; } = null!;
        public string DistrictName { get; set; } = null!;
        public District(int Id, string DistrictCode, string DivisionCode, string DistrictName)
        {
            this.Id = Id;
            this.DistrictCode = DistrictCode;
            this.DivisionCode = DivisionCode;
            this.DistrictName = DistrictName;
        }
    }
}
