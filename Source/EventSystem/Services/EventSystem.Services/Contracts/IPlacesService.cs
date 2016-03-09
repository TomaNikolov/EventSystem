namespace EventSystem.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using EventSystem.Models;

    public interface IPlacesService : IAdministrationService<Place>
    {
        IQueryable<Place> GetAll();

        int GetAllPage(string userId, int page, string orderBy, string search);

        int Create(string userId, string name, string description, int countryId, int cityId, double latitude, double longitude, string street, ICollection<Image> images);
    }
}
