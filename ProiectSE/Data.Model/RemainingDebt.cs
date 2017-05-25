using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Model
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