namespace EventSystem.Services.Contracts
{
    using System.Linq;
    using EventSystem.Models;

    public interface IEventsService : IAdministrationService<Event>
    {
        Event GetById(int id);

        IQueryable<Event> GetAll();
    }
}
