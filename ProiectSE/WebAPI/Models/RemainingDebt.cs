using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAPI.Models
{
    public class RemainingDebt
    {
        public int RemainingDebtId { get; set; }
        public int ApartmentId { get; set; }
        public string DebtTo { get; set; }
        public string Month { get; set; }
        public decimal AmountOfMoneyOwed { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}