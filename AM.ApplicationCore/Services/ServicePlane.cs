using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;


namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        private readonly IUnitOfWork _unitOfWork;


        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)

        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Plane plane)
        {
            _unitOfWork.Repository<Plane>().Add(plane);
        }

        public void Update(Plane plane)
        {
            _unitOfWork.Repository<Plane>().Update(plane);
        }

        public IList<Plane> GetAll()
        {
            return _unitOfWork.Repository<Plane>().GetAll().ToList();
        }

        public void Remove(Plane plane)
        {
            _unitOfWork.Repository<Plane>().Remove(plane);
        }

        public bool AvailablePlane(Flight flight, int n)
        {
            int capacity = Get(p => p.Flights.Contains(flight) == true).Capacity;
            int nbPassengers = flight.Tickets.Count();
            return capacity >= (nbPassengers + n);

        }
        public void DeletePlanes()
        {
            foreach (var plane in GetMany().Where(p => (DateTime.Now - p.ManufactureDate).TotalDays > 365 * 1).ToList())
            {
                Delete(plane);
                Commit();
            }
        }
        public IList<IGrouping<int, Flight>> GetFlights(int n)
        {
            return GetMany().OrderByDescending(p => p.PlaneId).Take(n).SelectMany(p => p.Flights)
                            .GroupBy(f => f.plane.PlaneId).ToList();
        }

        public IList<Passenger> GetPassengers(Plane plane)

        {
            return GetById(plane.PlaneId).Flights.SelectMany(f => f.Tickets.Select(t=> t.Passenger)).ToList();
        }


    } 
}

