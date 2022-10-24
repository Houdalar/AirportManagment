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
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) // bech na3mel configuration generale appliqué 3al les entités el kol fi 3outh bech na3mel les annotation 3al les attributs mta3 kol entity bel ka3ba bel ka3ba
        {
            //base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<String>().HaveMaxLength(50); // ma3neha 9oltelhom li ay string 3ana mayfoutech toulou 50
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date"); 



        }
    }
}
