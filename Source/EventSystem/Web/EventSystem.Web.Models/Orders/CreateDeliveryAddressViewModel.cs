namespace EventSystem.Web.Models.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class CreateDeliveryAddressViewModel
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
        [Display(Name ="Post Code")]
        [UIHint("String")]
        public string PostCode { get; set; }

        [Phone]
        [Required]
        [MaxLength(100)]
        [DataType(DataType.PhoneNumber)]
        [UIHint("String")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        [UIHint("String")]
        public string Email { get; set; }
    }
}
