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

    [TestClass]
    public class EventControllerTests
    {
        public const string EventDescription = "SomeContent";
        public const string UserName = "Pesho";
        public const string CategoryName = "Rock";

        private EventController eventController;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            AutoMapperConfig.RegisterMappings();
        }

        [TestInitialize]
        public void TestInit()
        {
            var eventServiceMock = new Mock<IEventsService>();
            eventServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new List<Event>()
                {
                    new Event()
                        {
                                Description = EventDescription,
                                User = new User() { UserName = UserName },
                                Category = new Category() { Name = CategoryName }
                        }
                }.AsQueryable());

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
    }
}
