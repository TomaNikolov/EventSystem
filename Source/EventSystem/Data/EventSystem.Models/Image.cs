namespace EventSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    using Data.Common.Models;

    public class Image : BaseModel<int>
    {
        /// [Required]
        /// [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Path { get; set; }

        [Required]
        [MaxLength(100)]
        public string ThumbnailPath { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
