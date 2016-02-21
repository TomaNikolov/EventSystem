namespace EventSystem.Services.Web
{
    using System;
    using System.Drawing;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;

    using Contracts;
    using Data.Common.Repositories;
    using Models;
   
    public class ImagesService : IImagesService
    {
        private const string RooDirectory = "~/App_Data/";

        private const string Thumbnail = "-thumbnail";

        private IDbRepository<Models.Image> images;

        public ImagesService(IDbRepository<Models.Image> images)
        {
            this.images = images;
        }

        public ICollection<int> SaveImages(string name, IEnumerable<HttpPostedFileBase> files)
        {
            var rootDir = HttpContext.Current.Server.MapPath(RooDirectory);
            var dir = Directory.CreateDirectory(Path.Combine(rootDir, name));
            var imageIds = new List<int>();

            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var originalImageName= Path.GetFileName(file.FileName);
                    var extension = originalImageName.Substring(originalImageName.LastIndexOf('.'));
                    var fileName = Guid.NewGuid().ToString();
                    var filePath =  name + "/" + fileName + extension;
                    var thumbnailfilePath = name + "/" + fileName + Thumbnail + extension;
                    var data = this.GetBiteArrayFromStream(file.InputStream);            
                    var thumbnail = CreateImageThumbnail(data);

                    var path = Path.Combine(rootDir + filePath);
                    file.SaveAs(path);

                    var thumbnailPath = Path.Combine(rootDir + thumbnailfilePath);
                    File.WriteAllBytes(thumbnailPath, thumbnail);

                    var image = this.SaveToImage(fileName, extension, RooDirectory + filePath, RooDirectory + thumbnailfilePath);
                    imageIds.Add(image.Id);
                }
            }

            return imageIds;
        }

        private byte[] GetBiteArrayFromStream(Stream inputStream)
        {
            MemoryStream memoryStream = new MemoryStream();
            inputStream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public byte[] CreateImageThumbnail(byte[] image, int width = 200, int height = 200)
        {
            using (var stream = new MemoryStream(image))
            {
                var img = System.Drawing.Image.FromStream(stream);
                var thumbnail = img.GetThumbnailImage(width, height, () => false, IntPtr.Zero);

                using (var thumbStream = new MemoryStream())
                {
                    thumbnail.Save(thumbStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return thumbStream.GetBuffer();
                }
            }
        }
      

        private Models.Image SaveToImage(string name, string type, string path, string thumbnailPath)
        {
            var image = new Models.Image()
            {
                Name = name,
                FileExtension = type, 
                Path = path,
                ThumbnailPath =thumbnailPath
            };

            this.images.Add(image);
            this.images.Save();

            return image;
        }
    }
}
