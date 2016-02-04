namespace EventSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class EventSystemDbContext : IdentityDbContext<User>
    {
        public EventSystemDbContext()
            : base("EventSustemDb")
        {
        }

        public IDbSet<Event> Events { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Ticket> Tickets { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Adress> Adresses { get; set; }

        public IDbSet<DeliveryAdress> DeliveryAdresses { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<OrderItem> OrderItems { get; set; }

        public IDbSet<Place> Places { get; set; }

        public IDbSet<Reservation> Reservations { get; set; }

        public static EventSystemDbContext Create()
        {
            return new EventSystemDbContext();
        }
    }
}
