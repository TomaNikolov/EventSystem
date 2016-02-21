namespace EventSystem.Services
{
    using System;
    using System.Linq;

    using Contracts;
    using Data.Common.Repositories;
    using EventSystem.Models;

    public class PlacesService : IPlacesService
    {
        private const int PageSize = 5;

        private IDbRepository<Place> places;

        public PlacesService(IDbRepository<Place> places)
        {
            this.places = places;
        }

        public IQueryable<Place> GetAll()
        {
            return this.places.All();
        }

        public Place GetById(object id)
        {
            return this.places.GetById(id);
        }

        public IQueryable<Place> GetByPage(int page, string orderBy, string search)
        {
            IQueryable<Place> result = this.places.All().OrderBy(x => x.CreatedOn);

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.Name.ToLower().Contains(search.ToLower()) || x.Description.ToLower().Contains(search.ToLower()));
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                //TODO
            }

            return result
                .Skip(PageSize * (page - 1))
                .Take(PageSize);
        }

        public int GetAllPage(int page, string orderBy, string search)
        {
            return (int)Math.Ceiling((double)this.GetByPage(page, orderBy, search).Count() / PageSize);
        }
    }
}
