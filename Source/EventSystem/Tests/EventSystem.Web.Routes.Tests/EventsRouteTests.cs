namespace EventSystem.Web.Routes.Tests
{
    using System.Web.Routing;

    using Config;
    using Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;
  
    [TestClass]
    public class EventsRouteTests
    {
        [TestMethod]
        public void TestEventDetails()
        {
            const string Url = "/Event/Details/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventController>(c => c.Details(1));
        }
    }
}
