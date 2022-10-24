using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {

        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(prop => prop.fullName,
                full =>
                {
                    full.Property(f => f.FirstName).HasColumnName("PassFirstName").HasMaxLength(30);
                    full.Property(f => f.LastName).HasColumnName("PassLastName").IsRequired();
                });
        }

    }
}
