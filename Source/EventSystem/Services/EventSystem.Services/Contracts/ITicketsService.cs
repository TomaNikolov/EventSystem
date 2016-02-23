namespace EventSystem.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;

    using EventSystem.Models;

    public interface ITicketsService
    {
        IQueryable<Ticket> GetById(int id);

        bool BuyTickets(ICollection<OrderItem> tickets);
    }
}
