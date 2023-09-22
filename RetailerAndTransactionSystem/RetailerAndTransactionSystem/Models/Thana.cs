namespace RetailerAndTransactionSystem.Models
{
    public class Thana
    {
        public int Id { get; set; }
        public string ThanaCode { get; set; } = null!;
        public string DistrictCode { get; set; } = null!;
        public string ThanaName { get; set; } = null!;
        public Thana(int Id, string ThanaCode, string DistrictCode, string ThanaName)
        {
            this.Id = Id;
            this.ThanaCode = ThanaCode;
            this.DistrictCode = DistrictCode;
            this.ThanaName = ThanaName;
            
        }
    }
}
