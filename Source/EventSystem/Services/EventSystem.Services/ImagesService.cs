namespace EventSystem.Services
{
    using Data.Common.Repositories;
    using EventSystem.Services.Contracts;
    using Models;

    public class ImagesService : IImagesService
    {
        private IDbRepository<Image> images;

        public ImagesService(IDbRepository<Image> images)
        {
            this.images = images;
        }

        public Image Save(string name, string type, string path, string thumbnailPath)
        {
            var image = new Models.Image()
            {
                Name = name,
                FileExtension = type,
                Path = path,
                ThumbnailPath = thumbnailPath
            };

            this.images.Add(image);
            this.images.Save();

            return image;
        }
    }
}
