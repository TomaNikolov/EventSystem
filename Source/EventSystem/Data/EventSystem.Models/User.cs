namespace EventSystem.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<DeliveryAdress> deliveryAdresses;
        private ICollection<Event> events;
        private ICollection<Place> places;

        public User()
        {
            this.deliveryAdresses = new HashSet<DeliveryAdress>();
            this.events = new HashSet<Event>();
            this.places = new HashSet<Place>();
        }

        public virtual ICollection<DeliveryAdress> DeliveryAdresses
        {
            get { return this.deliveryAdresses; }
            set { this.deliveryAdresses = value; }
        }

        public virtual ICollection<Place> Places
        {
            get { return this.places; }
            set { this.places = value; }
        }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}