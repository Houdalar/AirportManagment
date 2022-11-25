using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class Service<T> : IServices<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service( IUnitOfWork unitOfWork)
        {
            this._repository = unitOfWork.Repository<T>();
            this._unitOfWork = unitOfWork;
        }

        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }
        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }
        public virtual void Delete(T entity)
        {
            _repository.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            _repository.Delete(where);
        }
        public virtual T GetById(object id)
        {
            return
            _repository.GetById(id);
        }
        public T GetById(long id)
        {
            return
            _repository.GetById(id);
        }

        public virtual T GetById(string id)
        {
            return
            _repository.GetById(id);
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> filter = null)
        {
            return
            _repository.GetMany(filter);
        }
        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return
            _repository.Get(where);
        }
        public virtual void Dispose()
        {
            _unitOfWork.Dispose();
        }
        public void Commit()
        {
            try
            {
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
    }
}
