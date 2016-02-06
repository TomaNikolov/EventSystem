namespace EventSystem.Data.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<EventSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EventSystemDbContext context)
        {
            if (context.Events.Any())
            {
                return;
            }

            var users = new List<User>();

            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 5,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                var admin = new User
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                var se = manager.Create(admin, "admin");
                manager.AddToRole(admin.Id, "admin");

                for (int i = 1; i <= 5; i++)
                {
                    var user = new User
                    {
                        UserName = "user" + i + "@site.com",
                        Email = "user@site.com",
                    };

                    manager.Create(user, "user" + i);
                    users.Add(user);
                }

                context.SaveChanges();
            }

            var seed = new SeedData(users);

            seed.Events.ForEach(x => context.Events.Add(x));

            context.SaveChanges();
        }
    }
}


