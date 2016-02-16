namespace EventSystem.Services.Web.Contracts
{
    using EventSystem.Services.Contracts;
    using EventSystem.Web.Models.Orders;

    public interface IShoppingCartService : IService
    {
        ShoppingCartViewModel GetShopingCart();

        void AddTicket(OrderedTicketViewModel orderdTicket);

        void RemoveTicket(string Id);

        void Clear();
    }
}
