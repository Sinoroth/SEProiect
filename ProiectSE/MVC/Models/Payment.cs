using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int ApartmentId { get; set; }
        public string ServicesToBePaid { get; set; }
        public decimal AmountOfMoneyToBePaid { get; set; }
        public string Paid { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}