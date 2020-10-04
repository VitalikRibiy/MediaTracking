using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediaTracking.DAL.Context;
using MediaTracking.DAL.Models;
using MediaTracking.DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MediaTracking.DAL.Repositories.Implementations
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly MediaTrackingDbContext _context;
        protected DbSet<TEntity> _entities;

        public BaseRepository(MediaTrackingDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            return _entities.SingleOrDefaultAsync(t => t.Id.Equals(id));
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<TEntity>>(_entities);
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult<IEnumerable<TEntity>>(_entities.Where(predicate));
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            return (await _entities.AddAsync(entity)).Entity;
        }

        public virtual TEntity Remove(params object[] keys)
        {
            var model = _entities.Find(keys);
            if (model != null)
            {
                model = _entities.Remove(model).Entity;
            }

            return model;
        }

        public virtual TEntity Remove(TEntity entity)
        {
            return _entities.Remove(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _entities.Update(entity).Entity;
        }

        public virtual Task<IEnumerable<TEntity>> GetRangeAsync(uint index, uint amount)
        {
            return Task.FromResult<IEnumerable<TEntity>>(_entities.Skip((int)index).Take((int)amount));
        }
    }
}