namespace EventSystem.Services.Contracts
{
    using System.Linq;

    using Models;

    public interface ICountriesService
    {
        IQueryable<Country> GetAll();
    }
}
