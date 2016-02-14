namespace EventSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Common.Models;

    public class EventSystemDbContext : IdentityDbContext<User>
    {
        public EventSystemDbContext()
            : base("EventSystemDb")
        {
        }

        public IDbSet<Event> Events { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Ticket> Tickets { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<DeliveryAdress> DeliveryAdresses { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<OrderItem> OrderItems { get; set; }

        public IDbSet<Place> Places { get; set; }

        public IDbSet<Reservation> Reservations { get; set; }

        public static EventSystemDbContext Create()
        {
            return new EventSystemDbContext();
        }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
