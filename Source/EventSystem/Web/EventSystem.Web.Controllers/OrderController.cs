namespace EventSystem.Web.Controllers
{
    using System.Web.Mvc;

    using Infrastructure.Extensions;
    using Models.Orders;
    using Services.Contracts;
    using Services.Web.Contracts;
    using System.Linq;
    public class OrderController : Controller
    {
        private IShoppingCartService shoppingCartService;
        private ITicketsService ticketsService;

        public OrderController(IShoppingCartService shoppingCartService, ITicketsService ticketsService)
        {
            this.shoppingCartService = shoppingCartService;
            this.ticketsService = ticketsService;
        }

        public ActionResult Cart()
        {
            var model = this.shoppingCartService.GetShopingCart();
            return this.View(model);
        }

        [HttpPost]
        public ActionResult addToShoppingCart(int id, int quantity)
        {
            var orderedTicket = this.ticketsService.GetById(id)
                .To<OrderedTicketViewModel>()
                .FirstOrDefault();

            orderedTicket.Quantity = quantity;

            this.shoppingCartService.AddTicket(orderedTicket);

            return this.Json(new { });
        }
    }
}
