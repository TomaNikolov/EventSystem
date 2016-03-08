namespace EventSystem.Services.Web
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;

    using Contracts;
    using Services.Contracts;
    using EventSystem.Web.Infrastructure.Adapters;
    public class WebImagesService : IWebImagesService
    {
        private const string RooDirectory = "/Images/";

        private const string Thumbnail = "-thumbnail";

        private IImagesService images;

        private IMapPathAdapter serverUtilities;

        private IFileSaverAdapter fileSaver;

        private IDirectoryAdapter directory;

        public WebImagesService(IImagesService images, IMapPathAdapter serverUtilities, IFileSaverAdapter fileSaver, IDirectoryAdapter directory)
        {
            this.images = images;
            this.serverUtilities = serverUtilities;
            this.fileSaver = fileSaver;
            this.directory = directory;
        }

        public ICollection<int> SaveImages(string name, IEnumerable<HttpPostedFileBase> files)
        {
            var rootDir = this.serverUtilities.MapPath("~" + RooDirectory);
            this.directory.Create(Path.Combine(rootDir, name));
            var imageIds = new List<int>();

            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var originalImageName = Path.GetFileName(file.FileName);
                    var extension = originalImageName.Substring(originalImageName.LastIndexOf('.'));
                    var fileName = Guid.NewGuid().ToString();
                    var filePath = name + "/" + fileName + extension;
                    var thumbnailfilePath = name + "/" + fileName + Thumbnail + extension;
                    var data = this.GetBiteArrayFromStream(file.InputStream);
                    var thumbnail = this.CreateImageThumbnail(data);

                    var path = Path.Combine(rootDir + filePath);
                    file.SaveAs(path);

                    var thumbnailPath = Path.Combine(rootDir + thumbnailfilePath);
                    this.fileSaver.WriteAllBytes(thumbnailPath, thumbnail);

                    var image = this.images.Save(fileName, extension, RooDirectory + filePath, RooDirectory + thumbnailfilePath);
                    imageIds.Add(image.Id);
                }
            }

            return imageIds;
        }

        public byte[] CreateImageThumbnail(byte[] image, int width = 263, int height = 231)
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

        private byte[] GetBiteArrayFromStream(Stream inputStream)
        {
            MemoryStream memoryStream = new MemoryStream();
            inputStream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
