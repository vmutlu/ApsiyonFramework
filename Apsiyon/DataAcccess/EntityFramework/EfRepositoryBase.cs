using Apsiyon.Entities.Abstract;
using Apsiyon.Utilities.Linq;
using Apsiyon.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Apsiyon.DataAcccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : Entity, new() where TContext : DbContext, new()
    {
        protected readonly DbSet<TEntity> _dbSet;

        protected EfRepositoryBase(TContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _dbSet.Remove(entity); });
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, PaginationQuery paginationQuery = null, params Expression<Func<TEntity, object>>[] includeEntities)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeEntities.Length > 0)
                query = query.IncludeMultiple(includeEntities);

            if (paginationQuery != null)
            {
                var skip = (paginationQuery.PageNumber - 1) * paginationQuery.PageSize;
                query = query.Skip(skip).Take(paginationQuery.PageSize);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeEntities)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);
            if (includeEntities.Length > 0)
                query = query.IncludeMultiple(includeEntities);

            return await query.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _dbSet.Update(entity); });
        }
    }
}
