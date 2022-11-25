using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IServices<Plane>
    {
        public void Add(Plane plane);
        public void Remove(Plane plane);
        public IList<Plane> GetAll();

    }
}
