namespace EventSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    using Data.Common.Models;

    public class Image : BaseModel<int>
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string FileExtension { get; set; }

        [Required]
        [MaxLength(100)]
        public string Path { get; set; }

        [Required]
        [MaxLength(100)]
        public string ThumbnailPath { get; set; }
    }
}
