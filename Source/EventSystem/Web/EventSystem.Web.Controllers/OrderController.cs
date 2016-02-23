namespace EventSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using Microsoft.AspNet.Identity;

    using Base;
    using Infrastructure.Constants;
    using Infrastructure.Extensions;
    using Models.Orders;
    using Services.Contracts;
    using Services.Web.Contracts;
    using Infrastructure;
    using EventSystem.Models;
    using System.Collections.Generic;
    using Infrastructure.Notifications;
    public class OrderController : BaseController
    {
        private IShoppingCartService shoppingCartService;
        private ITicketsService ticketsService;
        private IDelliveryAddressesService delliveryAddressesService;
        private IOrdersService ordersService;

        public OrderController(IShoppingCartService shoppingCartService,
                                ITicketsService ticketsService,
                                IDelliveryAddressesService delliveryAddressesService,
                                IOrdersService ordersService)
        {
            this.shoppingCartService = shoppingCartService;
            this.ticketsService = ticketsService;
            this.delliveryAddressesService = delliveryAddressesService;
            this.ordersService = ordersService;
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

        [HttpGet]
        [Authorize]
        public ActionResult CreateAddress()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateAddress(CreateDeliveryAddressViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.Identity.GetUserId();
            int id = this.delliveryAddressesService.Create(userId, model.Country, model.City, model.Street, model.PostCode, model.Email, model.Phone);

            return this.RedirectToAction(x => x.ConfirmOrder(id));
        }



        [Authorize]
        public ActionResult ConfirmOrder(int id)
        {
            var model = new ConfirmOrderViewModel();
            model.ShoppingCart = this.shoppingCartService.GetShopingCart();
            model.DeliveryAddress = this.delliveryAddressesService
                .GetById(id)
                .To<DeliveryAddressViewModel>()
                .FirstOrDefault();
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult CheckOut(int addressId)
        {
            var userId = this.User.Identity.GetUserId();
            var shoppngCart = this.shoppingCartService.GetShopingCart();
            var tickets = this.Mapper.Map<ICollection<OrderItem>>(shoppngCart.OrderedTickets);
            var status = this.ordersService.Create(userId, addressId, tickets);

            if (!status)
            {
                this.shoppingCartService.RemoveTicketFormCart();
                this.AddToastMessage(Messages.Sorry, Messages.SomeOfTheTicketsAreAlreadySold, ToastType.Error);
                return this.RedirectToAction<OrderController>(c => c.Cart());
            }

            this.AddToastMessage(Messages.Congratulations, Messages.OrderWasCreared, ToastType.Success);
            return this.RedirectToAction<HomeController>(x => x.Index());
        }
    }
}
