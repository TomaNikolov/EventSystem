namespace EventSystem.Services
{
    using System;
    using System.Linq;
    using EventSystem.Data.Repositories;
    using EventSystem.Models;
    using EventSystem.Services.Contracts;

    public class CountriesService : ICountriesService
    {
        private IRepository<Country> countries;

        public CountriesService(IRepository<Country> countries)
        {
            this.countries = countries;
        }

        public IQueryable<Country> GetAll()
        {
            return this.countries.All();
        }
    }
}
