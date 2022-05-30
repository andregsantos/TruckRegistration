using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using TruckRegistration.Data.Entity;
using TruckRegistration.Data.EntityMap;

namespace TruckRegistration.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            DbInitializer.Initialize(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TruckMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
