namespace RetailerAndTransactionSystem.Models
{
    public class CustomerResponse
    {
        public int status { get; set; }
        public string message { get; set; } = null!;
        public string customer_id { get; set; } = null!;
        public List<Customer> results { get; set; } = null!;
        public CustomerResponse(){  }
        public CustomerResponse(int status, string message)
        {
            this.status = status;
            this.message = message;
        }

        public CustomerResponse(int status, string message, string customer_id)
        {
            this.status = status;
            this.message = message;
            this.customer_id = customer_id;
        }
        public CustomerResponse(int status, string message, List<Customer> results) {
            this.status = status;
            this.message = message;
            this.results = results;
        }       
    }
}
