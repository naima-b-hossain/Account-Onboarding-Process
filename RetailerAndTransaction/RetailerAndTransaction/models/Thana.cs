using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RetailerAndTransaction.models
{
    public class Thana
    {
        public int Id { get; set; }
        public string ThanaCode { get; set; } 
        public string DistrictCode { get; set; } 
        public string ThanaName { get; set; } 
        public Thana () { }
        public Thana(int Id, string ThanaCode, string DistrictCode, string ThanaName)
        {
            this.Id = Id;
            this.ThanaCode = ThanaCode;
            this.DistrictCode = DistrictCode;
            this.ThanaName = ThanaName;

        }
    }
}