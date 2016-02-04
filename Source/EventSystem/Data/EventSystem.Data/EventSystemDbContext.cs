namespace EventSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class EventSystemDbContext : IdentityDbContext<User>
    {
        public EventSystemDbContext()
            : base("EventSustemDb")
        {
        }

        public static EventSystemDbContext Create()
        {
            return new EventSystemDbContext();
        }
    }
}
