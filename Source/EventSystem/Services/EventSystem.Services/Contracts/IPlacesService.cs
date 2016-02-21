namespace EventSystem.Services.Contracts
{
    using System.Linq;
    using EventSystem.Models;
    using System.Collections.Generic;
    public interface IPlacesService : IAdministrationService<Place>
    {
        IQueryable<Place> GetAll();

        int GetAllPage(int page, string orderBy, string search);

        int Create(string name, string description, int countryId, int cityId, double Latitude, double Longitude, string Street, ICollection<int> ImageIds);
    }
}
