namespace EventSystem.Web
{
    using System.Data.Entity;

    using Data;
    using Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EventSystemDbContext, Configuration>());
            
            EventSystemDbContext.Create().Database.Initialize(true);
        }
    }
}