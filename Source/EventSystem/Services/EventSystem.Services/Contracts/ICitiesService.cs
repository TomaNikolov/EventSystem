namespace EventSystem.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface ICitiesService
    {
        IQueryable<City> GetAll();
    }
}
