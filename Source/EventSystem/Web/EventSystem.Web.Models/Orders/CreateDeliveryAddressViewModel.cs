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
        [Display(Name ="Phone Code")]
        public string PostCode { get; set; }

        [Phone]
        [Required]
        [MaxLength(100)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
