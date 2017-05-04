using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebAPI.Models
{
    public class OwnersAssociationContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<RemainingDebt> RemainingDebts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<NewsFeed> NewsFeeds { get; set; }
        public DbSet<WaterConsumption> WaterConsumptions { get; set; }

    }
}