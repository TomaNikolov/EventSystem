namespace EventSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using Infrastructure.Constants;
    using Infrastructure.Extensions;
    using Models.Orders;
    using Services.Contracts;
    using Services.Web.Contracts;

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

        public ActionResult GetShoppingCartItemsCount()
        {
            var count = this.shoppingCartService.GetItemsCount();

            return this.PartialView(Partials._ShoppingCartCount, count);
        }

        [HttpPost]
        public ActionResult addToShoppingCart(int id, int quantity)
        {
            var orderedTicket = this.ticketsService.GetById(id)
                .To<OrderedTicketViewModel>()
                .FirstOrDefault();

            orderedTicket.Quantity = quantity;

            this.shoppingCartService.AddTicket(orderedTicket);
            var count = this.shoppingCartService.GetItemsCount();

            return this.Json(new { ItemsCount = count });
        }

        [HttpPost]
        public ActionResult RemoveFromShoppingCart(string id)
        {
            this.shoppingCartService.RemoveTicket(id);
            var count = this.shoppingCartService.GetItemsCount();
            var totalPrice = this.shoppingCartService.GetTotalPrice();

            return this.Json(new { ItemsCount = count, TotalPrice = totalPrice });
        }

        [Authorize]
        public ActionResult SelectAddress()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult SelectAddress(int id)
        {
            //Add the adress to the order 
            //Add the adress to the user
            //save pending order to the data base 
            return this.RedirectToAction(x => x.ConfirmOrder(1));
        }

        [Authorize]
        public ActionResult ConfirmOrder(int id)
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult CheckOut(int id)
        {
            //Save Order to data base 
            //Clear Shopping cart
            //Add notification
            //Add success message

            return this.RedirectToAction<HomeController>(x => x.Index());
        }     
    }
}
