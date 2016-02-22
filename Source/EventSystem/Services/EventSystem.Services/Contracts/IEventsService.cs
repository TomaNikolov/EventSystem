namespace EventSystem.Services.Contracts
{
    using System.Linq;
    using EventSystem.Models;

    public interface IEventsService : IAdministrationService<Event>
    {
        Event GetById(int id);

        IQueryable<Event> GetAll();

        int GetAllPage(int page, string orderBy, string search);

        IQueryable<Event> GetByPage(int page, string orderby, string search, string place, string catogory, string country, string city);

        int GetAllPage(int page, string orderby, string search, string place, string catogory, string country, string city);
    }
}
