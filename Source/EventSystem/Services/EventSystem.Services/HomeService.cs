namespace EventSystem.Services
{
    using System;
    using System.Linq;

    using EventSystem.Data.Repositories;
    using EventSystem.Models;
    using EventSystem.Services.Contracts;

    public class HomeService : IHomeService
    {
        private IRepository<Event> events;

        public HomeService(IRepository<Event> events)
        {
            this.events = events;
        }

        public IQueryable<Event> GetAllEvents()
        {
            return this.events.All();
        }
    }
}
