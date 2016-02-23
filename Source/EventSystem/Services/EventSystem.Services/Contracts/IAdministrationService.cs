namespace EventSystem.Services.Contracts
{
    using System.Linq;

    public interface IAdministrationService<T>
        where T : class
    {
        IQueryable<T> GetByPage(string userId, int page, string orderBy, string search);

        T GetById(string userId, object id);
    }
}
