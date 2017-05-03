using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAPI.Models
{
    public class Contract
    {
        public int ContractId { get; set; }
        public string Supplier { get; set; }
        public string ContractPeriod { get; set; }
        public string ServicesFacilitiesOffered { get; set; }
        public decimal Cost { get; set; }
    }
}