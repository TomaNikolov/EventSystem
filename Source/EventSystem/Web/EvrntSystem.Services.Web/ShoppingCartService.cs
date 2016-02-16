namespace EvrntSystem.Services.Web
{
    using EventSystem.Data.Common.Repositories;
    using EventSystem.Models;
    using EvrntSystem.Services.Web.Contracts;

    public class ShoppingCartService : IShoppingCartService
    {
        private IDbRepository<City> cities;

        public ShoppingCartService(IDbRepository<City> cities)
        {
            this.cities = cities;
        }
    }
}
