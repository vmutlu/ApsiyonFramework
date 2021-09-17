using Apsiyon.Entities.Abstract;
using Apsiyon.Enums;
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
        protected readonly TContext _dbContext;

        protected EfRepositoryBase(TContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _dbSet.Remove(entity); });
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeEntities)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeEntities.Length > 0)
                query = query.IncludeMultiple(includeEntities);

            return await query.ToListAsync();
        }

        public async Task<PagingResult<TEntity>> GetAllForPagingAsync(int page, string propertyName, bool asc, Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeEntities)
        {
            using (var context = new TContext())
            {
                var list = context.Set<TEntity>().AsQueryable();

                if (includeEntities.Length > 0)
                    list = list.IncludeMultiple(includeEntities);

                if (filter != null)
                    list = list.Where(filter).AsQueryable();

                list = asc ? list.AscOrDescOrder(ESort.Asc, propertyName) : list.AscOrDescOrder(ESort.Desc, propertyName);
                int totalCount = list.Count();
                var start = (page - 1) * 10;
                list = list.Skip(start).Take(10);

                return new PagingResult<TEntity>(await list.ToListAsync(), totalCount, true, $"{totalCount} adet kayıt listelendi.");
            }
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
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
