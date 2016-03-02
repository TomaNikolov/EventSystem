using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventSystem.Services.Web.Contracts;
using EventSystem.Services.Contracts;
using Moq;
using EventSystem.Services.Web;
using System.Web;
using System.IO;
using System.Collections.Generic;
using EventSystem.Web.Models.Orders;
using System.Web.SessionState;
using EventSystem.Web.Infrastructure.Adapters;

namespace EventSystem.Web.Services.Tests
{
    public class MockHttpSession : HttpSessionStateBase
    {
        Dictionary<string, object> m_SessionStorage = new Dictionary<string, object>();

        public override object this[string name]
        {
            get { return m_SessionStorage[name]; }
            set { m_SessionStorage[name] = value; }
        }
    }

    [TestClass]
    public class ShoppingCartSeviceTests
    {
        [TestMethod]
        public void GetShoppingCartShouldReturnNewShoppingCartViewModel()
        {
            var mockTickets = new Mock<ITicketsService>();

            var mockSession = new Mock<HttpSessionStateBase>();
            var sessionAdapter = new Mock<ISessionAdapter>();
            sessionAdapter.Setup(x => x.Session).Returns(mockSession.Object);

            IShoppingCartService shoppingCart = new ShoppingCartService(mockTickets.Object, sessionAdapter.Object);

            var shoppingCartViewModel = shoppingCart.GetShopingCart();

            Assert.IsNotNull(shoppingCartViewModel);
        }
    }
}
