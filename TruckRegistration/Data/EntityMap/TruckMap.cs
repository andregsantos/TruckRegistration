using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruckRegistration.Data.Entity;

namespace TruckRegistration.Data.EntityMap
{
    public class TruckMap : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.ToTable("Trucks");

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Model)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.YearOfModel)
              .HasColumnType("varchar(100)")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(c => c.Year)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
