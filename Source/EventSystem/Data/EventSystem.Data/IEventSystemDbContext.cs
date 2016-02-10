namespace EventSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using EventSystem.Models;

    public interface IEventSystemDbContext
    {
        IDbSet<Event> Events { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Ticket> Tickets { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<DeliveryAdress> DeliveryAdresses { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<OrderItem> OrderItems { get; set; }

        IDbSet<Place> Places { get; set; }

        IDbSet<Reservation> Reservations { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
