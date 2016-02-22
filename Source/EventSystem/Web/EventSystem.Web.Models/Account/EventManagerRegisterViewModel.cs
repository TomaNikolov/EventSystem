namespace EventSystem.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class EventManagerRegisterViewModel
    {
        [Required]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [UIHint("String")]
        public string PhoneNumber { get; set; }
    }
}
