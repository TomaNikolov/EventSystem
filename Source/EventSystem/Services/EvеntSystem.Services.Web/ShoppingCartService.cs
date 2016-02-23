namespace EventSystem.Services.Web
{
    using System.Linq;
    using System.Web;

    using EventSystem.Web.Models.Orders;
    using EventSystem.Services.Web.Contracts;
    using System;

    public class ShoppingCartService : IShoppingCartService
    {
        private const string CartSessionKey = "Cart";

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
            var shopingCart = HttpContext.Current.Session[CartSessionKey];

            if (shopingCart == null)
            {
                shopingCart = new ShoppingCartViewModel();
                HttpContext.Current.Session[CartSessionKey] = shopingCart;
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
            throw new NotImplementedException();
        }
    }
}
