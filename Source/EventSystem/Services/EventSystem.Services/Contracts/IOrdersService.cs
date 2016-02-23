using System.Collections.Generic;
using EventSystem.Models;

namespace EventSystem.Services.Contracts
{
    public interface IOrdersService
    {
        bool Create(string userId, int addressId, ICollection<OrderItem> tickets);
    }
}
