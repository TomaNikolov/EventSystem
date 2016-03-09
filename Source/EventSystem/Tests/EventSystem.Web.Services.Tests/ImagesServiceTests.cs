namespace EventSystem.Web.Services.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;

    using EventSystem.Models;
    using EventSystem.Services.Contracts;
    using EventSystem.Services.Web;
    using Infrastructure.Adapters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
   
    [TestClass]
    public class ImagesServiceTests
    {
        private const string RandomString = "57b16eb8-e895-468d-963b-03fa3d609935";

        private WebImagesService imagesService;

        [TestInitialize]
        public void TestInit()
        {
            var mockImageService = new Mock<IImagesService>();
            mockImageService.Setup(x => x.Save(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string name, string type, string path, string thumbnailPath) =>
                { return new Image() { Name = name, FileExtension = type, Path = path, ThumbnailPath = thumbnailPath }; });

            var mockMapPathAdapter = new Mock<IMapPathAdapter>();
            mockMapPathAdapter.Setup(x => x.MapPath(It.IsAny<string>())).Returns(string.Empty);
            var mockDirectoryAdapter = new Mock<IDirectoryAdapter>();
            mockDirectoryAdapter.Setup(x => x.Create(It.IsAny<string>())).Verifiable();
            var mockFileSaverAdapter = new Mock<IFileSaverAdapter>();
            mockFileSaverAdapter.Setup(x => x.WriteAllBytes(It.IsAny<string>(), It.IsAny<byte[]>())).Verifiable();
            var mockGuidAdapter = new Mock<IGuidAdapter>();
            mockGuidAdapter.Setup(x => x.NewGuid()).Returns(RandomString);

            this.imagesService = new WebImagesService(mockImageService.Object,
                mockMapPathAdapter.Object, 
                mockFileSaverAdapter.Object,
                mockDirectoryAdapter.Object, 
                mockGuidAdapter.Object);
        }

        [TestMethod]
        public void ImagesPathsShouldMapCorrectly()
        {
            var postedFileMock = new Mock<HttpPostedFileBase>();
            postedFileMock.Setup(x => x.SaveAs(It.IsAny<string>())).Verifiable();
            postedFileMock.SetupGet(x => x.ContentType).Returns("image/jpeg");
            postedFileMock.SetupGet(x => x.FileName).Returns("RB1.jpg");
            postedFileMock.SetupGet(x => x.ContentLength).Returns(1);
            postedFileMock.SetupGet(x => x.InputStream).Returns(new MemoryStream(File.ReadAllBytes(@"..\..\Images\RB1.jpg")));

            var mockpostImages = new List<HttpPostedFileBase>() { postedFileMock.Object };

            var images = this.imagesService.SaveImages("pesho", mockpostImages);

            var image = images.FirstOrDefault();

            Assert.IsTrue(image.Name == RandomString);
            Assert.IsTrue(image.FileExtension == ".jpg");
            Assert.IsTrue(image.Path == "/Images/pesho/57b16eb8-e895-468d-963b-03fa3d609935.jpg");
            Assert.IsTrue(image.ThumbnailPath == "/Images/pesho/57b16eb8-e895-468d-963b-03fa3d609935-thumbnail.jpg");
        }
    }
}
