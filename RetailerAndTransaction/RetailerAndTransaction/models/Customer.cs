using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; } 
        public string CustomerGender { get; set; }
        public string CustomerFatherName { get; set; }
        public string CustomerMotherName { get; set; } 
        public string Nid { get; set; }
        public DateTime Dob { get; set; }
        public string Religion { get; set; }
        public string Occupation { get; set; } 
        public double MonthlyIncome { get; set; }
        public string PhoneNo { get; set; } 
        public string PerAddress { get; set; } 
        public string PerDivision { get; set; } 
        public string PerDistrict { get; set; } 
        public string PerThana { get; set; } 
        public string PerPostalCode { get; set; } 
        public string PreAddress { get; set; } 
        public string PreDivision { get; set; } 
        public string PreDistrict { get; set; } 
        public string PreThana { get; set; } 
        public string PrePostalCode { get; set; } 
        public string ComAddress { get; set; } 
        public string ComDivision { get; set; } 
        public string ComDistrict { get; set; } 
        public string ComThana { get; set; } 
        public string ComPostalCode { get; set; } 
        public string EmployeeId { get; set; }
        public double AccountBalance { get; set; } = 0;
        public Customer() { }
        public Customer(string CustomerName, double AccountBalance)
        {
            this.CustomerName = CustomerName;
            this.AccountBalance = AccountBalance;
        }
        public Customer(int Id, string CustomerId, string CustomerName, string CustomerGender, string CustomerFatherName, string CustomerMotherName, string Nid, DateTime Dob, string Religion, string Occupation, double MonthlyIncome, string PhoneNo, string PerAddress, string PerDivision, string PerDistrict, string PerThana, string PerPostalCode, string PreAddress, string PreDivision, string PreDistrict, string PreThana, string PrePostalCode, string ComAddress, string ComDivision, string ComDistrict, string ComThana, string ComPostalCode, string EmployeeId)
        {
            this.Id = Id;
            this.CustomerId = CustomerId;
            this.CustomerName = CustomerName;
            this.CustomerGender = CustomerGender;
            this.CustomerFatherName = CustomerFatherName;
            this.CustomerMotherName = CustomerMotherName;
            this.Nid = Nid;
            this.Dob = Dob;
            this.Religion = Religion;
            this.Occupation = Occupation;
            this.MonthlyIncome = MonthlyIncome;
            this.PhoneNo = PhoneNo;
            this.PerAddress = PerAddress;
            this.PerDivision = PerDivision;
            this.PerDistrict = PerDistrict;
            this.PerThana = PerThana;
            this.PerPostalCode = PerPostalCode;
            this.PreAddress = PreAddress;
            this.PreDivision = PreDivision;
            this.PreDistrict = PreDistrict;
            this.PreThana = PreThana;
            this.PrePostalCode = PrePostalCode;
            this.ComAddress = ComAddress;
            this.ComDivision = ComDivision;
            this.ComDistrict = ComDistrict;
            this.ComThana = ComThana;
            this.ComPostalCode = ComPostalCode;
            this.EmployeeId = EmployeeId;
        }
    }
}