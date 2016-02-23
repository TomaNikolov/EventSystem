namespace EventSystem.Services
{
    using System;
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
    }
}
