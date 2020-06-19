using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Data
{
    public class SampleAppContext : IdentityDbContext<StoreUser>
    {
        public SampleAppContext(DbContextOptions<SampleAppContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
               .HasData(new Order()
               {
                   Id = 1,
                   OrderDate = DateTime.UtcNow,
                   OrderNumber = "12345"
               });
        }
    }
}
