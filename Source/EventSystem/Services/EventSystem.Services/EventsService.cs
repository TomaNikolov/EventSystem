namespace EventSystem.Services
{
    using System;
    using System.Linq;

    using Data.Common.Repositories;
    using EventSystem.Services.Contracts;
    using Models;

    public class EventsService : IEventsService
    {
        private const int PageSize = 5;

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

        public int GetAllPage(int page, string orderBy, string search)
        {
            return (int)Math.Ceiling((double)this.GetByPage(page, orderBy, search).Count() / PageSize);
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

        public IQueryable<Event> GetByPage(int page, string orderBy, string search)
        {
            IQueryable<Event> result = this.events.All().OrderBy(x => x.CreatedOn);

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.Title.ToLower().Contains(search.ToLower()) || x.Description.ToLower().Contains(search.ToLower()));
            }

            if (string.IsNullOrEmpty(orderBy))
            {
                //TODO
            }

            return result
                .Skip(PageSize * (page - 1))
                .Take(PageSize);
        }
    }
}
