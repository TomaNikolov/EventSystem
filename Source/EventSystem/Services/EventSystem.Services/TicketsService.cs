﻿namespace EventSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using EventSystem.Data.Common.Repositories;
    using EventSystem.Models;

    public class TicketsService : ITicketsService
    {
        private IDbRepository<Ticket> tickets;
        private IDbRepository<OrderItem> orderItem;

        public TicketsService(IDbRepository<Ticket> tickets, IDbRepository<OrderItem> orderItem)
        {
            this.tickets = tickets;
            this.orderItem = orderItem;
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

                if (ticketToBeSold.Ammount < 0)
                {
                    return false;
                }
            }

            this.tickets.Save();

            return true;
        }

        public void Create(ICollection<OrderItem> tickets)
        {
            foreach (var item in tickets)
            {
                this.orderItem.Add(item);
            }

            this.orderItem.Save();
        }

        public IQueryable<Ticket> GetById(int id)
        {
            return this.tickets.All().Where(t => t.Id == id);
        }

        public bool HasQuantity(int ticketId, int quantity)
        {
            var ticket = this.tickets.GetById(ticketId);

            return ticket.Ammount - quantity >= 0;
        }

        public int Create(decimal price, int ammount, int eventId)
        {
            var ticket = new Ticket()
            {
                Price = price,
                Ammount = ammount,
                EventId = eventId
            };

            this.tickets.Add(ticket);
            this.tickets.Save();

            return ticket.Id;
        }
    }
}
