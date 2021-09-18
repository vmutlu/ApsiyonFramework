using Apsiyon.Entities.Abstract;
using Apsiyon.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Apsiyon.DataAcccess
{
    public interface IEntityRepository<T> where T : Entity, new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeEntities);
        Task<PagingResult<T>> GetAllForPagingAsync(int page, string propertyName, bool asc, Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includeEntities);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeEntities);
        Task AddAsync(T entity);
        void Add(T entity);
        Task UpdateAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(T entity);
        void Delete(T entity);
    }
}
