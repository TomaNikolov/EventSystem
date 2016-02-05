namespace EventSystem.Services.Contracts
{
    using EventSystem.Models;
    using System.Linq;

    public interface IHomeService
    {
        IQueryable<Event> GetAllEvents();
    }
}
