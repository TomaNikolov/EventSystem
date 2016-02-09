namespace EventSystem.Services.Contracts
{
    using System.Linq;

    using Models;

    public interface ICitiesService
    {
        IQueryable<City> GetAll();
    }
}
