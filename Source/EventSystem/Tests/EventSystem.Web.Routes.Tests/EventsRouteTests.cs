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

        [TestMethod]
        public void TestEventSearchWithPageParamether()
        {
            const string Url = "/Event/Search?page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventController>(c => c.Search(null, null, null,null,null,null, 1));
        }

        [TestMethod]
        public void TestEventSearchWithPageAndOrderByParamethers()
        {
            const string Url = "/Event/Search?Orderby=Category&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventController>(c => c.Search("Category", null, null, null, null, null, 1));
        }

        [TestMethod]
        public void TestEventSearchWithPageOrderBySearchParamethers()
        {
            const string Url = "/Event/Search?Orderby=Category&Search=Event&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventController>(c => c.Search("Category", "Event", null, null, null, null, 1));
        }

        [TestMethod]
        public void TestEventSearchWithPageOrderBySearchPlaceParamethers()
        {
            const string Url = "/Event/Search?Orderby=Category&Search=Event&Place=Fabric&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventController>(c => c.Search("Category", "Event", "Fabric", null, null, null, 1));
        }

        [TestMethod]
        public void TestEventSearchWithPageOrderBySearchPlaceCountryParamethers()
        {
            const string Url = "/Event/Search?Orderby=Category&Search=Event&Place=Fabric&Country=Bulgaria&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventController>(c => c.Search("Category", "Event", "Fabric", null, "Bulgaria", null, 1));
        }

        [TestMethod]
        public void TestEventSearchWithPageOrderBySearchPlaceCountryCityParamethers()
        {
            const string Url = "/Event/Search?Orderby=Category&Search=Event&Place=Fabric&Country=Bulgaria&City=Plovdiv&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventController>(c => c.Search("Category", "Event", "Fabric", null, "Bulgaria", "Plovdiv", 1));
        }

        [TestMethod]
        public void TestEventSearchWithPageOrderBySearchPlaceCountryCityCategoryParamethers()
        {
            const string Url = "/Event/Search?Orderby=Category&Search=Event&Place=Fabric&Country=Bulgaria&City=Plovdiv&Category=Rock&page=1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventController>(c => c.Search("Category", "Event", "Fabric", "Rock", "Bulgaria", "Plovdiv", 1));
        }
    }
}
