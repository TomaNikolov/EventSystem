namespace EventSystem.Services.Contracts
{
    using System.Linq;
    using Contracts;
    using EventSystem.Models;

    public interface IPlacesService : IAdministrationService<Place>
    {
        IQueryable<Place> GetAll();
    }
}
