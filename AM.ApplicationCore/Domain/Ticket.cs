using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public float Prix { get; set; }
        public int Siege { get; set; }
        public bool VIP { get; set; }

        public int FlightFK { get; set; }
        public string? PassengerFK { get; set; }

        // prop de navigation 

        public virtual Flight? Flight { get; set; }
        public virtual Passenger? Passenger { get; set; }

       
    }
}
