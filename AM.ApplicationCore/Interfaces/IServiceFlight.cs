using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        public List<DateTime> GetFlightDates(string destination);
        public void ShowFlightDetails(Plane plane);
        public int ProgrammedFlightNumber(DateTime startDate);
        public double DurationAverage(string destination);
        public List<Flight> OrderedDurationFlights();
        public List<Traveller> SeniorTravellers(Flight flight);
        public void Add(Flight flight);
        public void Remove(Flight flight);
        public IList<Flight> Getall();

    }
}
