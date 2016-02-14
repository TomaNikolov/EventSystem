namespace EventSystem.Services
{
    using System.Linq;

    using EventSystem.Data.Common.Repositories;
    using EventSystem.Models;
    using EventSystem.Services.Contracts;

    public class HomeService : IHomeService
    {
        private IDbRepository<Event> events;

        public HomeService(IDbRepository<Event> events)
        {
            this.events = events;
        }

        public IQueryable<Event> GetAllEvents()
        {
            return this.events.All();
        }

        public IQueryable<Event> GetTop(int count)
        {
            return this.events.All()
                 .OrderBy(e => e.Id)
                 .Take(count);
        }
    }
}
