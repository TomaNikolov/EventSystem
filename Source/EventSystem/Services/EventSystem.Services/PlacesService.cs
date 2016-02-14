namespace EventSystem.Services
{
    using System;
    using System.Linq;

    using Contracts;
    using Data.Common.Repositories;
    using EventSystem.Models;

    public class PlacesService : IPlacesService
    {
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

        public IQueryable<Place> GetByPage(int count, int skip)
        {
            throw new NotImplementedException();
        }
    }
}
