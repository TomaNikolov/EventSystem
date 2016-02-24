namespace EventSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Data.Common.Repositories;
    using EventSystem.Models;

    public class PlacesService : IPlacesService
    {
        private const int PageSize = 5;

        private IDbRepository<Place> places;
        private IDbRepository<Image> images;

        public PlacesService(IDbRepository<Place> places, IDbRepository<Image> images)
        {
            this.places = places;
            this.images = images;
        }

        public IQueryable<Place> GetAll()
        {
            return this.places.All();
        }

        public Place GetById(string userId, object id)
        {
            return this.places.GetById(id);
        }

        public int Create(string userId, string name, string description, int countryId, int cityId, double Latitude, double Longitude, string Street, ICollection<int> ImageIds)
        {
            var images = this.images.All().Where(x => ImageIds.Contains(x.Id)).ToList();
            var place = new Place()
            {
                Name = name,
                Description = description,
                CountryId = countryId,
                CityId = cityId,
                Longitude = Longitude,
                Latitude = Latitude,
                Street = Street,
                Images = images,
                UserId = userId
            };

            this.places.Add(place);
            this.places.Save();

            return place.Id;
        }

        public IQueryable<Place> GetByPage(string userId, int page, string orderBy, string search)
        {
            return this.GetQuery(userId, orderBy, search)
                       .Skip(PageSize * (page - 1))
                       .Take(PageSize);
        }

        public int GetAllPage(string userId,int page, string orderBy, string search)
        {
            return (int)Math.Ceiling((double)this.GetQuery(userId, orderBy, search).Count() / PageSize);
        }

        private IQueryable<Place> GetQuery(string userId, string orderBy, string search)
        {
            IQueryable<Place> result = this.places.All().Where(x => x.UserId == userId).OrderBy(x => x.CreatedOn);

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Description.ToLower().Contains(search.ToLower()));
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                //TODO
            }

            return result;
        }
    }
}
