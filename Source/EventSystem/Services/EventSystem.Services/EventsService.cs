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
        private const string EmptyString = "";

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

        public IQueryable<Event> GetById(int id)
        {
            return this.events.Include(x => x.Place.Images)
                .Where(x => x.Id == id);
        }

        public IQueryable<Event> GetTop()
        {
            return this.events.All()
                .OrderBy(x => x.EventStart)
                .Take(PageSize);
        }

        public IQueryable<Event> GetNew()
        {
            return this.events.All()
               .OrderBy(x => x.CreatedOn)
               .Take(PageSize);
        }

        public Event GetById(object id)
        {
            return this.events.GetById(id);
        }

        public int GetAllPage(int page, string orderBy, string search)
        {
            return (int)Math.Ceiling((double)this.GetQuery(orderBy, search).Count() / PageSize);
        }

        public int GetAllPage(int page, string orderby, string search, string place, string catogory, string country, string city)
        {
            return (int)Math.Ceiling((double)this.GetQuery(orderby, search, place, catogory, country, city).Count() / PageSize);
        }

        public IQueryable<Event> GetByPage(int page, string orderby, string search, string place, string catogory, string country, string city)
        {
            return this.GetQuery(orderby, search, place, catogory, country, city)
                       .Skip(PageSize * (page - 1))
                       .Take(PageSize);
        }

        public IQueryable<Event> GetByPage(int page, string orderBy, string search)
        {
            return this.GetQuery(orderBy, search)
                       .Skip(PageSize * (page - 1))
                       .Take(PageSize);
        }

        public IQueryable<Event> GetQuery(string orderby, string search, string place = EmptyString, string catogory = EmptyString, string country = EmptyString, string city = EmptyString)
        {
            IQueryable<Event> result = this.events.All().OrderBy(x => x.CreatedOn);

            if (!string.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.Title.ToLower().Contains(search.ToLower()) || x.Description.ToLower().Contains(search.ToLower()));
            }

            if (!string.IsNullOrEmpty(orderby))
            {
                //TODO
            }

            if (!string.IsNullOrEmpty(place))
            {
                result = result.Where(x => x.Place.Name.ToLower().Contains(place.ToLower()));
            }

            if (!string.IsNullOrEmpty(catogory))
            {
                result = result.Where(x => x.Category.Name.ToLower().Contains(catogory.ToLower()));
            }

            if (!string.IsNullOrEmpty(country))
            {
                result = result.Where(x => x.Place.Country.Name.ToLower().Contains(country.ToLower()));
            }

            if (!string.IsNullOrEmpty(city))
            {
                result = result.Where(x => x.Place.City.Name.ToLower().Contains(city.ToLower()));
            }

            return result;
        }
    }
}
