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
        public string DbPath { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

            var path =
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            DbPath = Path.Join(path, "truck.db");

            DbInitializer.Initialize(this);

        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
     => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TruckMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
