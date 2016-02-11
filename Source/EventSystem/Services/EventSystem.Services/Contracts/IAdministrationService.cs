namespace EventSystem.Services.Contracts
{
    using System.Linq;

    public interface IAdministrationService<T>
        where T : class
    {
        IQueryable<T> GetByPage(int count, int skip);

        T GetById(object id);
    }
}
