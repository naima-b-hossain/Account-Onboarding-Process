using System;
using System.Collections.Generic;

namespace RetailerAndTransactionSystem.Models;
public class EmployeeInfo
{
    public int Id { get; set; }

    public string EmployeeId { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public string EmployeePhoneNo { get; set; } = null!;

    public string BranchCode { get; set; } = null!;

    public string BranchName { get; set; } = null!;




public EmployeeInfo(int Id, string EmployeeId, string EmployeeName, string EmployeePhoneNo, string BranchCode, string BranchName)
    {
        this.Id = Id;
        this.EmployeeId = EmployeeId;
        this.EmployeeName = EmployeeName;
        this.EmployeePhoneNo = EmployeePhoneNo;
        this.BranchCode = BranchCode;
        this.BranchName = BranchName;
        
        
    }

}
