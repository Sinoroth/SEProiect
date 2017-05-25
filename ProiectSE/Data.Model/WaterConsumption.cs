using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Model
{
    public class WaterConsumption
    {
        public int WaterConsumptionId { get; set; }
        public int ApartmentId { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Consumption { get; set; }
        public decimal AmountOfMoneyOwed { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}