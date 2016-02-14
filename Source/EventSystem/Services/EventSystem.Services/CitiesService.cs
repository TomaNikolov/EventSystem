namespace EventSystem.Services
{
    using System;
    using System.Linq;

    using Data.Repositories;
    using EventSystem.Services.Contracts;
    using Models;

    public class CitiesService : ICitiesService
    {
        private IDbRepository<City> cities;

        public CitiesService(IDbRepository<City> cities)
        {
            this.cities = cities;
        }

        public IQueryable<City> GetAll()
        {
            return this.cities.All();
        }
    }
}
