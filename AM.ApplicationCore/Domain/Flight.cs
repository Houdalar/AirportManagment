using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string? AirlineLogo { get; set; }
        public int FlightId { get; set; }
        [ForeignKey("PlaneId")] // mech lazem fou9 attribut betharoura 
        public int? PlaneId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public string? Departure { get; set; }
        public  string? Destination { get; set; }
        public virtual Plane? plane { get; set; }

        public virtual List<Passenger>? Passengers { get; set; }
        public virtual List<Ticket>? Tickets { get; set; }
        

        public override string ToString()
        {
            return "FlightId: " + FlightId + " FlightDate: " + FlightDate + " EstimatedDuration: " + EstimatedDuration + " EffectiveArrival: " + EffectiveArrival + " Departure: " + Departure + " Destination: " + Destination;
        }

    }

    
}