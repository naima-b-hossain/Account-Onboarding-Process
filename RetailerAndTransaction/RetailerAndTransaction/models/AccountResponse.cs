using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class AccountResponse
    {
        public int status { get; set; }
        public string message { get; set; } 
        public string account_no { get; set; } 
        public List<Account> results { get; set; } 
        public AccountResponse() { }
        public AccountResponse(int status, string message)
        {
            this.status = status;
            this.message = message;
        }

        public AccountResponse(int status, string message, string account_no)
        {
            this.status = status;
            this.message = message;
            this.account_no = account_no;
        }
        public AccountResponse(int status, string message, List<Account> results)
        {
            this.status = status;
            this.message = message;
            this.results = results;
        }
    }
}