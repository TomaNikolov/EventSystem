namespace EventSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        //[Required]
        //[MaxLength(100)]
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
