using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class Employee
    {
        public int Id { get; set; }

        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; } 

        public string EmployeePhoneNo { get; set; } 

        public string BranchCode { get; set; }  

        public string BranchName { get; set; }

        public Employee() { }
        public Employee(int Id, string EmployeeId, string EmployeeName, string EmployeePhoneNo, string BranchCode, string BranchName)
        {
            this.Id = Id;
            this.EmployeeId = EmployeeId;
            this.EmployeeName = EmployeeName;
            this.EmployeePhoneNo = EmployeePhoneNo;
            this.BranchCode = BranchCode;
            this.BranchName = BranchName;
        }
    }
}