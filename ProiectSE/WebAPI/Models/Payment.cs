using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string ApartmentNumber { get; set; }
        public string ServicesToBePaid { get; set; }
        public decimal AmountOfMoneyToBePaid { get; set; }
    }
}