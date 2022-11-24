using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;


namespace AM.ApplicationCore.Services
{
    public class ServicePlane : IServicePlane
    {
        private IUnitOfWork unitOfWork;

        public ServicePlane(IUnitOfWork unitOfWork)

        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Plane plane)
        {
            unitOfWork.Repository<Plane>().Add(plane);
        }

        public void Update(Plane plane)
        {
            unitOfWork.Repository<Plane>().Update(plane);
        }

        public IList<Plane> GetAll()
        {
           return unitOfWork.Repository<Plane>().GetAll().ToList();
        }

        public void Remove(Plane plane)
        {
            unitOfWork.Repository<Plane>().Remove(plane);
        }

    }

}

