namespace EventSystem.Models
{
    using EventSystem.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class DeliveryAddress : BaseModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(100)]
        public string PostCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}