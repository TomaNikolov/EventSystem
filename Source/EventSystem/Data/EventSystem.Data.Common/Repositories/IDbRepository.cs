namespace EventSystem.Data.Common.Repositories
{
    using System.Linq;

    using Common.Models;

    public interface IDbRepository<T> : IDbRepository<T, int>
        where T : BaseModel<int>
    {
    }
   
    public interface IDbRepository<T, in TKey> : IDbGenericRepository<T, TKey>
    where T : BaseModel<TKey>
    {
        IQueryable<T> AllWithDeleted();

        void HardDelete(T entity);
    }
}
