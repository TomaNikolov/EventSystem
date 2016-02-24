namespace EventSystem.Data.Common.Repositories
{
    using Common.Models;

    public interface IDbRepository<T> : IDbRepository<T, int>
        where T : BaseModel<int>
    {
    }

    public interface IDbRepository<T, in TKey> : IDbGenericRepository<T, TKey>
    where T : class, IHavePrimaryKey<TKey>, IAuditInfo, IDeletableEntity
    {
        T GetById(TKey id);
    }
}
