using Apsiyon.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Apsiyon.DataAcccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
