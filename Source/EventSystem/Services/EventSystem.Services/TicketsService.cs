namespace EventSystem.Services
{
    using System;

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

        public IQueryable<Ticket> GetById(int id)
        {
            return this.tickets.All().Where(t => t.Id == id);
        }
    }
}
