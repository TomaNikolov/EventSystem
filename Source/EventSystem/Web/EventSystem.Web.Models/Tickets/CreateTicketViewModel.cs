namespace EventSystem.Web.Models.Tickets
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTicketViewModel
    {
        [UIHint("String")]
        public decimal Price { get; set; }

        [UIHint("String")]
        public int Ammount { get; set; }
    }
}
