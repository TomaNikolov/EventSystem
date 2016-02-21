namespace EventSystem.Services.Contracts
{
    using System.Linq;

    public interface IAdministrationService<T>
        where T : class
    {
        IQueryable<T> GetByPage(int page, string orderBy, string search);

        T GetById(object id);
    }
}
