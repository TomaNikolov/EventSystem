namespace EventSystem.Services
{
    using System;
    using System.Linq;

    using Data.Repositories;
    using EventSystem.Services.Contracts;
    using Models;

    public class CitiesService : ICitiesService
    {
        private IRepository<City> cities;

        public CitiesService(IRepository<City> cities)
        {
            this.cities = cities;
        }

        public IQueryable<City> GetAll()
        {
            return this.cities.All();
        }
    }
}
