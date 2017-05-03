using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAPI.Models
{
    public class NewsFeed
    {
        public int NewsFeedId { get; set; }
        public string News { get; set; }
        public DateTime Date { get; set; }
    }
}
