namespace EventSystem.Services.Contracts
{
    using System.Linq;
    using EventSystem.Models;

    public interface IEventsService : IAdministrationService<Event>
    {
        Event GetById(int id);

        IQueryable<Event> GetAll();

        IQueryable<Event> GetByPage(int page, string orderBy, string search);

        int GetAllPage(int page, string orderBy, string search);
    }
}
