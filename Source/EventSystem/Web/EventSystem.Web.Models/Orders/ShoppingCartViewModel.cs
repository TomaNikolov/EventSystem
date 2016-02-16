namespace EventSystem.Web.Models.Orders
{
    using System.Collections.Generic;

    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            this.OrderedTickets = new List<OrderedTicketViewModel>();
        }

        public ICollection<OrderedTicketViewModel> OrderedTickets { get; set; }
    }
}
