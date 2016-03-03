namespace EventSystem.Services.Web
{
    using System.Collections.Generic;
    using System.Linq;

    using EventSystem.Services.Web.Contracts;
    using EventSystem.Web.Models.Orders;
    using Services.Contracts;
    using EventSystem.Web.Infrastructure.Adapters;

    public class ShoppingCartService : IShoppingCartService
    {
        private const string CartSessionKey = "Cart";

        private ITicketsService ticketsService;
        private ISessionAdapter sessionAdapter;

        public ShoppingCartService(ITicketsService ticketsService, ISessionAdapter sessionAdapter)
        {
            this.ticketsService = ticketsService;
            this.sessionAdapter = sessionAdapter;
        }

        public void AddTicket(OrderedTicketViewModel orderdTicket)
        {
            this.GetShopingCart().OrderedTickets.Add(orderdTicket);
        }

        public void Clear()
        {
            this.GetShopingCart().OrderedTickets.Clear();
        }

        public int GetItemsCount()
        {
            return this.GetShopingCart().OrderedTickets.Count;
        }

        public ShoppingCartViewModel GetShopingCart()
        {
            var shopingCart = this.sessionAdapter.Session[CartSessionKey];

            if (shopingCart == null)
            {
                shopingCart = new ShoppingCartViewModel();
                this.sessionAdapter.Session[CartSessionKey] = shopingCart;
            }

            return (ShoppingCartViewModel)shopingCart;
        }

        public decimal GetTotalPrice()
        {
            return this.GetShopingCart().OrderedTickets.Sum(x => x.Quantity * x.Price);
        }

        public void RemoveTicket(string id)
        {
            var shoppingCart = this.GetShopingCart();
            var itemToRemove = shoppingCart.OrderedTickets
                  .FirstOrDefault(x => x.Id == id);

            if (itemToRemove != null)
            {
                shoppingCart.OrderedTickets.Remove(itemToRemove);
            }
        }

        public void RemoveTicketFormCart()
        {
            var shoppingCart = this.GetShopingCart();
            var ticketToRemove = new List<OrderedTicketViewModel>();

            foreach (var ticket in shoppingCart.OrderedTickets)
            {
                if (!this.ticketsService.HasQuantity(ticket.TicketId, ticket.Quantity))
                {
                    ticketToRemove.Add(ticket);
                }
            }

            foreach (var ticket in ticketToRemove)
            {
                shoppingCart.OrderedTickets.Remove(ticket);
            }
        }
    }
}
