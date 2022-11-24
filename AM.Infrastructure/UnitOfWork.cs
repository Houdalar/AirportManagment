using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class UnitOfWork
    {
        private readonly DbContext _context;
        private readonly Type _repositoryType;
        private bool disposeValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposeValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposeValue = true;
            }
        }
        ~UnitOfWork()
        {
            Dispose(disposing : false);
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public UnitOfWork(DbContext context, Type repositoryType)
        {
            _context = context;
            _repositoryType = repositoryType;

        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            return (IGenericRepository<T>)Activator.CreateInstance(_repositoryType
                .MakeGenericType(typeof(T)), _context);
        }

        public int Save() 
        { 
            return _context.SaveChanges();
        }

    }
}
