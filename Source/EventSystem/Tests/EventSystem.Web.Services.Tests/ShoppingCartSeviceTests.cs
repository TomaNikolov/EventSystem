namespace EventSystem.Web.Services.Tests
{
    using EventSystem.Services.Contracts;
    using EventSystem.Services.Web;
    using EventSystem.Services.Web.Contracts;
    using Infrastructure.Adapters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Orders;
    using Moq;
    using Setups;

    [TestClass]
    public class ShoppingCartSeviceTests
    {
        private IShoppingCartService shoppingCart;

        [TestInitialize]
        public void TestInit()
        {
            var mockTickets = new Mock<ITicketsService>();
            mockTickets.Setup(x => x.HasQuantity(It.IsAny<int>(), 1)).Returns(true);

            var mockSession = new MockHttpSession();

            var sessionAdapter = new Mock<ISessionAdapter>();
            sessionAdapter.Setup(x => x.Session).Returns(mockSession);

            this.shoppingCart = new ShoppingCartService(mockTickets.Object, sessionAdapter.Object);
        }

        [TestMethod]
        public void GetShoppingCartShouldReturnNewShoppingCartViewModel()
        {
            var shoppingCartViewModel = this.shoppingCart.GetShopingCart();

            Assert.IsNotNull(shoppingCartViewModel);
        }

        [TestMethod]
        public void AddTicketShouldAddItemPropertly()
        {
            var orderedTicket = new OrderedTicketViewModel();
            this.shoppingCart.AddTicket(orderedTicket);

            var shoppingCart = this.shoppingCart.GetShopingCart();

            Assert.IsTrue(1 == shoppingCart.OrderedTickets.Count);
        }

        [TestMethod]
        public void AddTicketShouldRemoveItemPropertly()
        {
            var ticketId = "1";

            var orderedTicket = new OrderedTicketViewModel() { Id = ticketId };
            this.shoppingCart.AddTicket(orderedTicket);

            var cart = this.shoppingCart.GetShopingCart();

            Assert.IsTrue(1 == cart.OrderedTickets.Count);

            this.shoppingCart.RemoveTicket(ticketId);

            Assert.IsTrue(0 == cart.OrderedTickets.Count);
        }

        [TestMethod]
        public void GetTotalProiceShouldCalculatedCorrectly()
        {
            var firstOrder = new OrderedTicketViewModel() { Quantity = 2, Price = 10 };
            var secondOrder = new OrderedTicketViewModel() { Quantity = 2, Price = 10 };
            this.shoppingCart.AddTicket(firstOrder);
            this.shoppingCart.AddTicket(secondOrder);

            var totalPrice = this.shoppingCart.GetTotalPrice();

            Assert.IsTrue(40 == totalPrice);
        }

        [TestMethod]
        public void ClearShouldRemoveAllItemsFromCart()
        {
            var firstOrder = new OrderedTicketViewModel() ;
            var secondOrder = new OrderedTicketViewModel() ;
            this.shoppingCart.AddTicket(firstOrder);
            this.shoppingCart.AddTicket(secondOrder);

            this.shoppingCart.Clear();

            var ticketCount = this.shoppingCart.GetShopingCart().OrderedTickets.Count;

            Assert.IsTrue(ticketCount == 0);
        }

        [TestMethod]
        public void RemoveFromCartShouldRemoveTicketIfThereIsNoQuantity()
        {
            var firstOrder = new OrderedTicketViewModel() { TicketId = 1, Quantity = 1, Price = 10 };
            var secondOrder = new OrderedTicketViewModel() {TicketId = 2, Quantity = 2, Price = 10 };
            this.shoppingCart.AddTicket(firstOrder);
            this.shoppingCart.AddTicket(secondOrder);

            this.shoppingCart.RemoveTicketFormCart();

            var ticketCount = this.shoppingCart.GetShopingCart().OrderedTickets.Count;

            Assert.IsTrue(ticketCount == 1);
        }
    }
}
