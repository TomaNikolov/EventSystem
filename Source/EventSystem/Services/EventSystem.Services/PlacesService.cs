namespace EventSystem.Services
{
    using System;
    using System.Linq;
    using EventSystem.Data.Repositories;
    using EventSystem.Models;
    using Contracts;

    public class PlacesService : IPlacesService
    {
        private IRepository<Place> places;

        public PlacesService(IRepository<Place> places)
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

        public IQueryable<Place> GetByPage(int count, int skip)
        {
            throw new NotImplementedException();
        }
    }
}
