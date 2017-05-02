using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAPI.Models
{
    public class NewsFeed
    {
        public int NewsId { get; set; }
        public string News { get; set; }
        public DateTime Data { get; set; }
    }
}
