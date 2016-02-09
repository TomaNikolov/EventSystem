namespace EventSystem.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface ICountriesService
    {
        IQueryable<Country> GetAll();
    }
}
