using System;
using System.Collections.Generic;

namespace RetailerAndTransactionSystem.Models;

public class Customer
{
    public int Id { get; set; }

    public string CustomerId { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string CustomerGender { get; set; } = null!;

    public string CustomerFatherName { get; set; } = null!;

    public string CustomerMotherName { get; set; } = null!;

    public string Nid { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Religion { get; set; } = null!;

    public string Occupation { get; set; } = null!;

    public double MonthlyIncome { get; set; }

    public string PhoneNo { get; set; } = null!;

    public string PerAddress { get; set; } = null!;

    public string PerDivision { get; set; } = null!;

    public string PerDistrict { get; set; } = null!;

    public string PerThana { get; set; } = null!;

    public string PerPostalCode { get; set; } = null!;

    public string PreAddress { get; set; } = null!;

    public string PreDivision { get; set; } = null!;

    public string PreDistrict { get; set; } = null!;

    public string PreThana { get; set; } = null!;

    public string PrePostalCode { get; set; } = null!;

    public string ComAddress { get; set; } = null!;

    public string ComDivision { get; set; } = null!;

    public string ComDistrict { get; set; } = null!;

    public string ComThana { get; set; } = null!;

    public string ComPostalCode { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public double AccountBalance { get; set; } = 0;

    public Customer() { }

    public Customer(string CustomerName, double AccountBalance) 
    {
        this.CustomerName = CustomerName;
        this.AccountBalance = AccountBalance;   
    }
    public Customer(int Id, string CustomerId, string CustomerName, string CustomerGender, string CustomerFatherName, string CustomerMotherName, string Nid, DateTime Dob,string Religion,string Occupation, double MonthlyIncome,string PhoneNo, string PerAddress, string PerDivision, string PerDistrict, string PerThana, string PerPostalCode, string PreAddress, string PreDivision, string PreDistrict, string PreThana, string PrePostalCode, string ComAddress, string ComDivision, string ComDistrict, string ComThana, string ComPostalCode, string EmployeeId)
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
