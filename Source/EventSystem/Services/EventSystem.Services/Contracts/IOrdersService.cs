namespace EventSystem.Services.Contracts
{
    using System.Collections.Generic;
    using EventSystem.Models;

    public interface IOrdersService
    {
        bool Create(string userId, int addressId, ICollection<OrderItem> tickets);
    }
}
