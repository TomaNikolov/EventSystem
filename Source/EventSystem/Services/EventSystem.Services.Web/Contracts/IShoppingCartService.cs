﻿namespace EventSystem.Services.Web.Contracts
{
    using EventSystem.Web.Models.Orders;

    public interface IShoppingCartService
    {
        ShoppingCartViewModel GetShopingCart();

        void AddTicket(OrderedTicketViewModel orderdTicket);

        void RemoveTicket(string id);

        void Clear();

        int GetItemsCount();

        decimal GetTotalPrice();

        void RemoveTicketFormCart();
    }
}
