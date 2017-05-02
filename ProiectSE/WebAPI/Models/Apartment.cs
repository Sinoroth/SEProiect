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
        public string Owner { get; set; }
        public string ApartmentNumber { get; set; }
        public int NumberOfOccupants { get; set; }
        public decimal AmountOfMoneyOwed { get; set; }
    }
}