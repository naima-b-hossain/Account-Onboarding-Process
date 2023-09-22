using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictCode { get; set; } 
        public string DivisionCode { get; set; } 
        public string DistrictName { get; set; }
        public District() { }
        public District(int Id, string DistrictCode, string DivisionCode, string DistrictName)
        {
            this.Id = Id;
            this.DistrictCode = DistrictCode;
            this.DivisionCode = DivisionCode;
            this.DistrictName = DistrictName;
        }
    }
}