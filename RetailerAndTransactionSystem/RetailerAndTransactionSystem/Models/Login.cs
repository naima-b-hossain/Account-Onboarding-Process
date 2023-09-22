namespace RetailerAndTransactionSystem.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string EmpEmail { get; set; } = null!;
        public string EmpPassword { get; set; } = null!;
        public string EmployeeId { get; set; } = null!;
        public Login() { }
        public Login(string EmpEmail, string EmpPassword)
        {
            this.EmpEmail = EmpEmail;
            this.EmpPassword = EmpPassword;
        }
        public Login(int Id, string EmpEmail, string EmpPassword, string EmployeeId)
        {
            this.Id = Id;
            this.EmpEmail = EmpEmail;
            this.EmpPassword = EmpPassword;
            this.EmployeeId = EmployeeId;
        }
    }
}
