namespace EventSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using EventSystem.Data.Common.Repositories;
    using EventSystem.Models;

    public class TicketsService : ITicketsService
    {
        private IDbRepository<Ticket> tickets;

        public TicketsService(IDbRepository<Ticket> tickets)
        {
            this.tickets = tickets;
        }

        public bool BuyTickets(ICollection<OrderItem> tickets)
        {
            var ticketsId = tickets.Select(x => x.TicketId);
            var ticketsToBeSold = this.tickets
                                    .All()
                                    .Where(t => ticketsId.Contains(t.Id))
                                    .ToList();

            foreach (var ticketToBeSold in ticketsToBeSold)
            {
                var orderedTicket = tickets.FirstOrDefault(x => x.TicketId == ticketToBeSold.Id);
                ticketToBeSold.Ammount -= orderedTicket.Quantity;

                if(ticketToBeSold.Ammount < 0)
                {
                    return false;
                }
            }

            this.tickets.Save();

            return true;
        }

        public IQueryable<Ticket> GetById(int id)
        {
            return this.tickets.All().Where(t => t.Id == id);
        }
    }
}
