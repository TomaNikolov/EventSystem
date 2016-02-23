namespace EventSystem.Services.Contracts
{
    using System.Linq;

    using EventSystem.Models;

    public interface IDelliveryAddressesService
    {
        int Create(string userId, string country, string city, string street, string postCode, string email, string phone);

        IQueryable<DeliveryAddress> GetById(int id);

        IQueryable<DeliveryAddress> GetUserAdresses(string userId);
    }
}
