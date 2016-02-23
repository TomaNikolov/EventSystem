namespace EventSystem.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Data.Common.Repositories;
    using EventSystem.Services.Contracts;
    using Models;

    public class OrdersService : IOrdersService
    {
        private IDbRepository<Order> orders;
        private INotificationsService notificationsService;
        private ITicketsService ticketsService;

        public OrdersService( IDbRepository<Order> orders, INotificationsService notificationsService, ITicketsService ticketsService)
        {
            this.orders = orders;
            this.notificationsService = notificationsService;
            this.ticketsService = ticketsService;
        }

        public bool Create(string userId, int addressId, ICollection<OrderItem> tickets)
        {
            this.ticketsService.Create(tickets);

            if (!this.ticketsService.BuyTickets(tickets))
            {
                return false;
            }

            var order = new Order()
            {
                UserId = userId,
                DeliveryAdressId = addressId,
                OrderItems = tickets
            };

            foreach (var ticket in tickets) 
            {
                this.notificationsService.Create(ticket.Ticket.EventId, NotificationType.TicketSold);
            }

            this.orders.Add(order);
            this.orders.Save();

            return true;
        }
    }
}
