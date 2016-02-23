namespace EventSystem.Services
{
    using System;
    using System.Linq;
    using Data.Common.Repositories;
    using EventSystem.Services.Contracts;
    using Models;

    public class DelliveryAddressesService : IDelliveryAddressesService
    {
        private IDbRepository<DeliveryAddress> deliveryAddresses;

        private IUsersService usersService;

        public DelliveryAddressesService(IDbRepository<DeliveryAddress> deliveryAddresses, IUsersService usersService)
        {
            this.deliveryAddresses = deliveryAddresses;
            this.usersService = usersService;
        }

        public int Create(string userId, string country, string city, string street, string postCode, string email, string phone)
        {
            var deliveryAddress = new DeliveryAddress()
            {
                Country = country,
                City = city,
                Street =street,
                PostCode = postCode,
                Email = email,
                Phone = phone,
                UserId = userId
            };

            this.deliveryAddresses.Add(deliveryAddress);
            this.deliveryAddresses.Save();

            return deliveryAddress.Id;
        }

        public IQueryable<DeliveryAddress> GetById(int id)
        {
            return this.deliveryAddresses.All()
                .Where(d => d.Id == id);
        }

        public IQueryable<DeliveryAddress> GetUserAdresses(string userId)
        {
            return this.deliveryAddresses.All()
                 .Where(d => d.UserId == userId);
        }
    }
}
