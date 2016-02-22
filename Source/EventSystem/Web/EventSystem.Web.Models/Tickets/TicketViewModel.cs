namespace EventSystem.Web.Models.Tickets
{
    using EventSystem.Models;
    using Infrastructure.Mappings;

    public class TicketViewModel : IMapFrom<Ticket>
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int Ammount { get; set; }
    }
}
