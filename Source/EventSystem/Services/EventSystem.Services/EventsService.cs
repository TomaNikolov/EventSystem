namespace EventSystem.Services
{
    using System.Linq;

    using Data.Common.Repositories;
    using EventSystem.Services.Contracts;
    using Models;

    public class EventsService : IEventsService
    {
        private IDbRepository<Event> events;

        public EventsService(IDbRepository<Event> events)
        {
            this.events = events;
        }

        public IQueryable<Event> GetAllEvents()
        {
            return this.events.All();
        }

        public Event GetById(int id)
        {
            return this.events
                .All()
                .FirstOrDefault(e => e.Id == id);
        }
    }
}
