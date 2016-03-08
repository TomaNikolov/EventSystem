namespace EventSystem.Services
{
    using System;
    using Models;
    using EventSystem.Services.Contracts;
    using Data.Common.Repositories;
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
