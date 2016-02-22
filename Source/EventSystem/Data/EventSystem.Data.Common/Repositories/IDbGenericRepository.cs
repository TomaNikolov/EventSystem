namespace EventSystem.Data.Common.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IDbGenericRepository<T, in TKey>
         where T : class
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        IQueryable<T> Include(Expression<Func<T, object>> expression);
      
        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}
