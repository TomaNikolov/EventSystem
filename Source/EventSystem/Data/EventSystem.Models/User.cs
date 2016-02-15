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

        public User()
        {
            this.deliveryAdresses = new HashSet<DeliveryAdress>();
        }

        public virtual ICollection<DeliveryAdress> DeliveryAdresses
        {
            get { return this.deliveryAdresses; }
            set { this.deliveryAdresses = value; }
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