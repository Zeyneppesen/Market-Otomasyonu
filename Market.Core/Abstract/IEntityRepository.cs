using System.Collections.Generic;
using System.Linq.Expressions;
using Market.Core.Data.Entities;

namespace Market.Core.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

    }
}

