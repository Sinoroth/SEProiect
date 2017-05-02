using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string ApartmentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}