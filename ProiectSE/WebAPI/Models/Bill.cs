using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAPI.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public int ApartmentId { get; set; }
        public string BillType { get; set; }
        public string Month { get; set; }
        public decimal AmountOfMoneyOwed { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}

