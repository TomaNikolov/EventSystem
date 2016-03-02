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
        public void TestIntt()
        {
            var mockTickets = new Mock<ITicketsService>();

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
        public void AddTicketShoudAddItemPropertly()
        {
            var orderedTicket = new OrderedTicketViewModel();
            this.shoppingCart.AddTicket(orderedTicket);

            var shoppingCart = this.shoppingCart.GetShopingCart();

            Assert.IsTrue(1 == shoppingCart.OrderedTickets.Count);
        }

        [TestMethod]
        public void AddTicketShoudRemoveItemPropertly()
        {
            var ticketId = "1";

            var orderedTicket = new OrderedTicketViewModel() { Id = ticketId};
            this.shoppingCart.AddTicket(orderedTicket);
            
            var shoppingCart = this.shoppingCart.GetShopingCart();

            Assert.IsTrue(1 == shoppingCart.OrderedTickets.Count);

            this.shoppingCart.RemoveTicket(ticketId);

            Assert.IsTrue(0 == shoppingCart.OrderedTickets.Count);
        }
    }
}
