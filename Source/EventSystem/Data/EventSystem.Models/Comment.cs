namespace EventSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    using Data.Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Content { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}