using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight

    {
        public Action<Plane>? FlightDetailsDel;
        public Func<string, double>? DurationAverageDel;

        public ServiceFlight()
        {
            /*FlightDetailsDel = ShowFlightDetails;
            DurationAverageDel = DurationAverage;*/
            FlightDetailsDel = p =>
            {
                var query = from f in Flights
                            where f.plane == p
                            select new { f.Destination, f.FlightDate };
                foreach (var f in query)
                    Console.WriteLine("flights date " + f.FlightDate + "Destination" + f.Destination);
            };

            DurationAverageDel = dest =>
            {
                var query = from x in Flights
                            where x.Destination == dest
                            select x.EstimatedDuration;
                return (float)query.Average();
            };
        }
        public List<Flight> ?Flights { get; set; }
        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> listeDate = new List<DateTime>();
            /*for (int i = 0; i < Flights.Count; i++)
            
                if(Flights[i].Destination == destination)
                    listeDate.Add(Flights[i].FlightDate);
                return listeDate;*/
            /*
            foreach (Flight f in Flights)
            
                if(f.Destination.Equals(destination))
                    listeDate.Add(f.FlightDate);
            return listeDate;
            */

            /*var query = from x in Flights
                        where x.Destination == destination
                        select x.FlightDate;
            return query.ToList();*/

            return Flights.Where(x => x.Destination == destination).Select(x => x.FlightDate).ToList(); ;


        }

        public void ShowFlightDetails(Plane plane)
        {
            //linq
            /*
            // var query = from x in plane.Flights select x;
             var query = from x in plane.Flights 
                         select new { x.FlightDate, x.Destination };
            */
            //lambda
            var query = plane.Flights.Select(x => new { x.FlightDate, x.Destination });
            foreach (var flight in query.ToList())
            {
                Console.WriteLine("Date: " + flight.FlightDate +
                    " Destination: " + flight.Destination);
            }



        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            /*var query = from x in Flights
                       where DateTime.Compare(x.FlightDate, startDate) > 0 &&
                       (x.FlightDate - startDate).TotalDays < 7
                       select x;
            return query.Count();*/
            return Flights.Where(x =>
                DateTime.Compare(x.FlightDate, startDate) > 0 &&
                       (x.FlightDate - startDate).TotalDays < 7).Select(x => x).Count();
        }

        public float DurationAverage(string destination)
        {
            /*var query = from x in Flights
                        where x.Destination == destination
                        select x.EstimatedDuration;
            return (float)query.Average();*/
            return (float)Flights.Where(f => f.Destination == destination).
               Select(f => f.EstimatedDuration).Average();
        }

        public List<Flight> OrderedDurationFlights()
        {
            return ((from x in Flights
                    orderby x.EstimatedDuration descending
                    select x).ToList());
        }

        public List<Traveller> SeniorTravellers(Flight flight)
        {
            return flight.Passengers.OfType<Traveller>().OrderBy(x => x.BirthDate).Take(3).ToList();
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var query = from x in Flights
                        group x by x.Destination;
            foreach (var flight in query)
            {
                Console.WriteLine("Destination: " + flight.Key);
                foreach (var d in flight)
                {
                    Console.WriteLine("Décollage: " + d.FlightDate);
                }
            }
            return query;
        }


            public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))
                            Console.WriteLine(f);
                    }
                    break;
            }
        }
    }
}
