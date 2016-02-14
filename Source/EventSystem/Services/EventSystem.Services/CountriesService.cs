namespace EventSystem.Services
{
    using System;
    using System.Linq;
    using EventSystem.Data.Repositories;
    using EventSystem.Models;
    using EventSystem.Services.Contracts;

    public class CountriesService : ICountriesService
    {
        private IDbRepository<Country> countries;

        public CountriesService(IDbRepository<Country> countries)
        {
            this.countries = countries;
        }

        public IQueryable<Country> GetAll()
        {
            return this.countries.All();
        }
    }
}
