using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrainBookingPlatform.DAL.Entities;
using TrainBookingPlatform.DAL.Repository.Interfaces;

namespace TrainBookingPlatform.DAL.Repository.Classes
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly TrainBookingPlatformDbContext dbContext;
        protected readonly DbSet<T> table;

        public BaseRepository(TrainBookingPlatformDbContext dbContext)
        {
            this.dbContext = dbContext;
            table = dbContext.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return table.Where(predicate).AsNoTracking();

            return table.AsNoTracking();
        }

        public async Task<IQueryable<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return table
                    .Where(predicate).AsNoTracking();

            return table.AsNoTracking();
        }

        public int CountAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
                return table
                    .Where(predicate)
                    .Count();

            return table.Count();
        }

        public async Task Commit()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<T> Create(T entity, bool commit = true)
        {
            var entry = await table.AddAsync(entity);
            entity = entry.Entity;
            if (commit)
                await Commit();

            return entity;
        }

        public async Task<T> Update(T entity, bool commit = true)
        {
            table.Update(entity);

            if (commit)
                await Commit();

            return entity;
        }

        public async Task<T> Delete(T entity, bool commit = true)
        {
            table.Remove(entity);

            if (commit)
                await Commit();

            return entity;
        }
    }
}
