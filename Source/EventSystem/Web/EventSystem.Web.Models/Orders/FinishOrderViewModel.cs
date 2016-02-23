namespace EventSystem.Web.Models.Orders
{
    using System.ComponentModel.DataAnnotations;

    public class FinishOrderViewModel
    {
        [Required]
        public int AddressId { get; set; }
    }
}
