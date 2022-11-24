using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AM.Infrastructure
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        //private readonly  _unitOfWork;
        public GenericRepository(DbContext context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        { 
            _dbSet.Update(entity);
        }
        public void Delete(Expression<Func<T,bool>> where)
        {
            _dbSet.RemoveRange(_dbSet.Where(where));
        }

        public T Get(Expression<Func<T,bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault();
        }
        public T GetById(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }
         public IEnumerable<T> GetMany(Expression<Func<T,bool>> where)
        {
            return _dbSet.Where(where).AsEnumerable();
        }
    } 
}
