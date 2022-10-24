using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    
    {
            public void Configure(EntityTypeBuilder<Flight> builder)
            {
                //Many-to-Many
                builder.HasMany(f => f.Passengers).WithMany(p => p.Flights)
                .UsingEntity(j => j.ToTable("Reservation")); // rename table d'association
                //One-to-Many
                builder.HasOne(f => f.plane).WithMany(pl=>pl.Flights)
                .HasForeignKey(f=>f.PlaneId)
                .OnDelete(DeleteBehavior.ClientSetNull); // foreign key set at null if the associated entity is deleted
                
            }
        
    }
}
