namespace EventSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data.Common.Repositories;
    using EventSystem.Services.Contracts;
    using Models;

    public class EventsService : IEventsService
    {
        private const int PageSize = 5;
        private const string EmptyString = "";

        private IDbRepository<Event> events;
        private ITicketsService ticketsService;
        private IDbRepository<Image> images;

        public EventsService(IDbRepository<Event> events, ITicketsService ticketsService, IDbRepository<Image> images)
        {
            this.events = events;
            this.ticketsService = ticketsService;
            this.images = images;
        }

        public IQueryable<Event> GetAll()
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

        public Event GetById(string userId, object id)
        {
            return this.events.All()
                .Where(x => x.Id == (int)id && x.UserId == userId).FirstOrDefault();
        }

        public int GetAllPage(string userId, int page, string orderBy, string search)
        {
            return (int)Math.Ceiling((double)this.GetQuery(userId, orderBy, search).Where(e => e.UserId == userId).Count() / PageSize);
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

        public IQueryable<Event> GetByPage(string userId, int page, string orderBy, string search)
        {
            return this.GetQuery(userId, orderBy, search)
                       .Where(e => e.UserId == userId)
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
                ///TODO
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

        public int Create(string userId, string title, string description, DateTime eventStart, int categoryId, int placeId, ICollection<Image> images)
        {
            var newEvent = new Event()
            {
                Title = title,
                Description = description,
                EventStart = eventStart,
                CategoryId = categoryId,
                PlaceId = placeId,
                UserId = userId,
                Images = images
            };

            this.events.Add(newEvent);
            this.events.Save();

            return newEvent.Id;
        }

        public IQueryable<Event> GetById(string userId, int id)
        {
            return this.events.All()
                .Where(x => x.Id == id && x.UserId == userId);
        }
    }
}
