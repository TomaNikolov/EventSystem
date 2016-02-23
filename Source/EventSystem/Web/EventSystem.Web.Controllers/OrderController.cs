namespace EventSystem.Web.Controllers
{
    using System.Collections.Generic;
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
    using EventSystem.Models;
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
            var userId = this.User.Identity.GetUserId();
            var model = this.delliveryAddressesService.GetUserAdresses(userId)
                .To<DeliveryAddressViewModel>()
                .ToList();

            return this.View(model);
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

            if (!model.ShoppingCart.OrderedTickets.Any())
            {
                this.AddToastMessage(Messages.Sorry, Messages.NoItems, ToastType.Info);
                return this.RedirectToAction<HomeController>(c => c.Index());
            }

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult FinishOrder(FinishOrderViewModel model)
        {
            if(!this.ModelState.IsValid)
            {
                this.AddToastMessage(Messages.Sorry, Messages.Propblem, ToastType.Error);
                return this.RedirectToAction<HomeController>(x => x.Index());
            }

            var userId = this.User.Identity.GetUserId();
            var shoppngCart = this.shoppingCartService.GetShopingCart();
            var tickets = this.Mapper.Map<ICollection<OrderItem>>(shoppngCart.OrderedTickets);


            if(!tickets.Any())
            {
                this.AddToastMessage(Messages.Sorry, Messages.NoItems, ToastType.Info);
                return this.RedirectToAction<HomeController>(c => c.Index());
            }

            var hasTickets = this.ordersService.Create(userId, model.AddressId, tickets);

            if (!hasTickets)
            {
                this.shoppingCartService.RemoveTicketFormCart();
                this.AddToastMessage(Messages.Sorry, Messages.SomeOfTheTicketsAreAlreadySold, ToastType.Error);
                return this.RedirectToAction(c => c.Cart());
            }

            this.shoppingCartService.Clear();
            this.AddToastMessage(Messages.Congratulations, Messages.OrderWasCreared, ToastType.Success);
            return this.RedirectToAction<HomeController>(x => x.Index());
        }
    }
}
