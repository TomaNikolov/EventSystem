namespace EventSystem.Web.Models.Images
{
    using EventSystem.Models;
    using Infrastructure.Mappings;

    public class ImageViewModel : IMapFrom<Image>
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public string ThumbnailPath { get; set; }
    }
}
