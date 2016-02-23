using EventSystem.Models;

namespace EventSystem.Services.Contracts
{

   public interface IDelliveryAddressesService
    {
        int Create(string userId, string country, string city, string street, string postCode, string email, string phone);
    }
}
