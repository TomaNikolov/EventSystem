namespace EventSystem.Services
{
    using System;
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

        public IQueryable<Event> GetAll()
        {
            return this.events.All();
        }

        public IQueryable<Event> GetAllEvents()
        {
            return this.events.All();
        }

        public Event GetById(object id)
        {
            return this.events.GetById(id);
        }

        public Event GetById(int id)
        {
            return this.events
                .Include(e => e.Tickets)
                .FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<Event> GetByPage(int count, int skip)
        {
            throw new NotImplementedException();
        }
    }
}
