namespace EventSystem.Web.Services.Tests
{
    using Data.Common.Repositories;
    using EventSystem.Models;
    using EventSystem.Services.Contracts;
    using EventSystem.Services.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Web;
    [TestClass]
    public class ImagesServiceTests
    {
        private WebImagesService imagesService;

        [TestInitialize]
        public void TestInit()
        {
            var mockImageService = new Mock<IImagesService>();
            mockImageService.Setup(x => x.Save(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string name, string type, string path,string thumbnailPath) =>
                { return new Image() { Name = name, Path = path, ThumbnailPath = thumbnailPath }; });

          //  this.imagesService = new WebImagesService(mockImageService.Object);
        }

        [TestMethod]
        public void Testtest()
        {
            var mockImageService = new Mock<IImagesService>();
            mockImageService.Setup(x => x.Save(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string name, string type, string path, string thumbnailPath) =>
                { return new Image() { Name = name, Path = path, ThumbnailPath = thumbnailPath }; });

            var mock = mockImageService.Object;
            var image = mock.Save("snimka", "tip", "sda/asd", "asd/asd/thumbnail");
        }
    }
}
