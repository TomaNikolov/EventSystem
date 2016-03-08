namespace EventSystem.Web.Services.Tests
{
    using Data.Common.Repositories;
    using EventSystem.Models;
    using EventSystem.Services.Contracts;
    using EventSystem.Services.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    [TestClass]
    public class ImagesServiceTests
    {
        private ImagesService imagesService;

        [TestInitialize]
        public void TestInit()
        {
            var mockImageRepository = new Mock<IDbRepository<Image>>();
            this.imagesService = new ImagesService(mockImageRepository.Object);
        }
    }
}
