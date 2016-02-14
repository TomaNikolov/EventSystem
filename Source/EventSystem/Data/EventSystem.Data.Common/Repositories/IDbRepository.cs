namespace EventSystem.Data.Common.Repositories
{
    using System.Linq;

    using Common.Models;
    using System.Linq.Expressions;
    using System;
    public interface IDbRepository<T> : IDbRepository<T, int>
        where T : BaseModel<int>
    {
    }

    public interface IDbRepository<T, in TKey>
        where T : BaseModel<TKey>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        IQueryable<T> Include(Expression<Func<T, object>> expression);

        T GetById(TKey id);

        T GetById(object id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}
