using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RepTec.Core.Entity;
using Microsoft.Data.Entity;

namespace RepTec.DataAccess
{
    public class EfGenericRepository<TEntity, TIdentity> : IDisposable where TEntity : Entity<TIdentity>, new()
    {
        private DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected EfGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            _context.ChangeTracker.DetectChanges();
        }

        public virtual int GetCount(Expression<Func<TEntity, bool>> whereProperties = null)
        {
            return AggregateQueryProperties(_dbSet.AsNoTracking(), whereProperties).Count();
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> whereProperties = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return AggregateQueryProperties(_dbSet.AsNoTracking(), whereProperties, includeProperties).ToList();
        }

        public virtual List<TEntity> SkipAndTake(int skipNumber, int amount, Expression<Func<TEntity, bool>> whereProperties = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return AggregateQueryProperties(_dbSet.AsNoTracking(), whereProperties, includeProperties)
                .Skip(skipNumber).Take(amount).ToList();
        }

        public virtual TEntity GetByСondition(Expression<Func<TEntity, bool>> whereProperties = null,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return AggregateQueryProperties(_dbSet.AsNoTracking(), whereProperties, includeProperties).FirstOrDefault();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(TIdentity id)
        {
            var entity = new TEntity { Id = id };
            Delete(entity);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public virtual void Delete(IEnumerable<TEntity> entitiesToDelete)
        {
            _dbSet.RemoveRange(entitiesToDelete);
            _context.ChangeTracker.DetectChanges();
        }

        public virtual int Save()
        {
            return _context.SaveChanges();
        }

        private static IQueryable<TSource> AggregateQueryProperties<TSource>(IQueryable<TSource> table,
            Expression<Func<TSource, bool>> whereProperties = null,
            params Expression<Func<TSource, object>>[] includeProperties) where TSource : Entity<TIdentity>
        {
            var query = includeProperties.Aggregate(table, (current, includeProperty) => current.Include(includeProperty));

            if (whereProperties != null)
            {
                query = query.Where(whereProperties);
            }

            return query.OrderBy(e => e.Id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            try
            {
                _context.Dispose();
                _context = null;
            }
            catch { }
        }
    }
}