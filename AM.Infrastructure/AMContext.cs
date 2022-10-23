using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Flight>? Flights { get; set; }
        public virtual DbSet<Passenger>? Passengers { get; set; }
        public virtual DbSet<Plane>? Planes { get; set; }
        public virtual DbSet<Staff>? Staff { get; set; }
        public virtual DbSet<Traveller>? Travellers  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
        }



    }
}
