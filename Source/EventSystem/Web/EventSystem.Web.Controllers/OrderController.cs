﻿namespace EventSystem.Web.Controllers
{
    using System.Web.Mvc;

    using Infrastructure.Extensions;
    using Models.Orders;
    using Services.Contracts;
    using Services.Web.Contracts;
    using System.Linq;
    using Infrastructure.Constants;
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

            return this.Json(new { ItemsCount = count });
        }
    }
}
