namespace EventSystem.Web.Models.Events
{
    using EventSystem.Models;
    using EventSystem.Web.Infrastructure.Mappings;

    public class TicketViewModel : IMapFrom<Ticket>
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int Ammount { get; set; }
    }
}
