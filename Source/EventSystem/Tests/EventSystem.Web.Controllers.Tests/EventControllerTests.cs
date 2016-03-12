namespace EventSystem.Web.Controllers.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Config;
    using EventSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models.Events;
    using Moq;
    using Services.Contracts;

    using TestStack.FluentMVCTesting;
    using Models.PagingAndSorting;
    [TestClass]
    public class EventControllerTests
    {
        public const string EventDescription = "SomeContent";
        public const string UserName = "Pesho";
        public const string CategoryName = "Rock";
        public const string ThumbnailPath = "ThumbnailPath";

        private EventController eventController;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            AutoMapperConfig.RegisterMappings();
        }

        [TestInitialize]
        public void TestInit()
        {
            var events = new List<Event>()
                {
                    new Event()
                        {
                                Description = EventDescription,
                                User = new User() { UserName = UserName },
                                Category = new Category() { Name = CategoryName },
                                Place = new Place () {Name = "Bar Fabric", City = new City() {Name = "Plovdiv" } },
                                Images = new List<Image>() {new Image() { ThumbnailPath = "ThumbnailPath" } }
                        }
                };
            var eventServiceMock = new Mock<IEventsService>();
            eventServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(events.AsQueryable());
            eventServiceMock.Setup(x => x.GetByPage(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .Returns(events.AsQueryable());
            eventServiceMock.Setup(x => x.GetAllPage(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
              .Returns(1);
            this.eventController = new EventController(eventServiceMock.Object);
        }

        [TestMethod]
        public void DetailsShouldWorkCorrectly()
        {
            this.eventController.WithCallTo(x => x.Details(1))
                .ShouldRenderView("Details")
                .WithModel<EventDetailsViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(CategoryName, viewModel.CategoryName);
                        Assert.AreEqual(UserName, viewModel.UserName);
                        Assert.AreEqual(EventDescription, viewModel.Description);
                    }).AndNoModelErrors();
        }

        [TestMethod]
        public void SearchShouldWorkCorrectly()
        {
            this.eventController.WithCallTo(x => x.Search(null, null, null, null, null, null, 0))
                .ShouldRenderView("Search")
                .WithModel<EventsPagableAndSortbleViewModel<EventsSearchViewModel>>(
                    viewModel =>
                    {
                        Assert.AreEqual(1, viewModel.Page);
                        Assert.AreEqual(CategoryName, viewModel.Data.FirstOrDefault().CategoryName);
                        Assert.AreEqual(EventDescription, viewModel.Data.FirstOrDefault().Description);
                    }).AndNoModelErrors();
        }
    }
}
