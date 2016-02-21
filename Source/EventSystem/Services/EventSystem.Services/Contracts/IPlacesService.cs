namespace EventSystem.Services.Contracts
{
    using System.Linq;
    using EventSystem.Models;

    public interface IPlacesService : IAdministrationService<Place>
    {
        IQueryable<Place> GetAll();

        int GetAllPage(int page, string orderBy, string search);
    }
}
