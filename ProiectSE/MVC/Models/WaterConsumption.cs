using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
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