namespace EventSystem.Services
{
    using System.Linq;

    using Data.Repositories;
    using EventSystem.Services.Contracts;
    using Models;

    public class EventsService : IEventsService
    {
        private IRepository<Event> events;

        public EventsService(IRepository<Event> events)
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
