using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;

namespace TrainBookingPlatform.DAL.Repository.Interfaces
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        void Commit();
        Task<T> Create(T entity, bool commit = true);
        T Update(T entity, bool commit = true);
        T Delete(T entity, bool commit = true);
    }
}
