using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class User
    {
        public int id { get; set; } 
        public string empEmail { get; set; }
        public string empPassword { get; set; }    
        public string employeeId { get; set; }   

        public User() { }
        public User(string empEmail, string empPassword)
        {
            this.empEmail=empEmail;
            this.empPassword=empPassword;
        }
        public User(int id, string empEmail, string empPassword, string employeeId)
        {
            this.id=id;
            this.empEmail=empEmail;
            this.empPassword=empPassword;
            this.employeeId=employeeId;
        }   
    }
}