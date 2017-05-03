using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAPI.Models
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string ApartmentNumber { get; set; }
        public int UserId { get; set; }
        public int NumberOfOccupants { get; set; }
        public decimal AmountOfMoneyOwed { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<RemainingDebt> RemainingDebts { get; set; }
        //public virtual ICollection<WaterConsumption> WaterConsumptions { get; set; }
    }
}