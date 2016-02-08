namespace EventSystem.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All();

        IQueryable<T> Include(Expression<Func<T, object>> expression);

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        int SaveChanges();
    }
}
