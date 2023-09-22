namespace RetailerAndTransactionSystem.Models
{
    public class SubProduct
    {
        public int Id { get; set; }
        public string SubProductType { get; set; } = null!;
        public string ProductType { get; set; } = null!;
        public string SubProductName { get; set; } = null!;
        public SubProduct() { }
        public SubProduct(int Id, string SubProductType, string ProductType, string SubProductName)
        {
            this.Id = Id;
            this.SubProductType = SubProductType;
            this.ProductType = ProductType;
            this.SubProductName = SubProductName;
        }
    }
}
