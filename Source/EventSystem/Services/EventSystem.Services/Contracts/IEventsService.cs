namespace EventSystem.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EventSystem.Models;

    public interface IEventsService : IAdministrationService<Event>
    {
        IQueryable<Event> GetById(int id);

        IQueryable<Event> GetById(string userId, int id);

        IQueryable<Event> GetAll();

        IQueryable<Event> GetTop();

        IQueryable<Event> GetNew();

        int GetAllPage(string userId, int page, string orderBy, string search);

        IQueryable<Event> GetByPage(int page, string orderby, string search, string place, string catogory, string country, string city);

        int GetAllPage(int page, string orderby, string search, string place, string catogory, string country, string city);

        int Create(string userId, string title, string description, DateTime eventStart, int categoryId, int placeId, ICollection<int> ImageIds);
    }
}
