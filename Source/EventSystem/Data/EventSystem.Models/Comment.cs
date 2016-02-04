namespace EventSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}