using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class Division
    {
        public int Id { get; set; }
        public string DivisionCode { get; set; } 
        public string DivisionName { get; set; }
        public Division() { }
        public Division(int Id, string DivisionCode, string DivisionName)
        {
            this.Id = Id;
            this.DivisionCode = DivisionCode;
            this.DivisionName = DivisionName;
        }
    }
}
