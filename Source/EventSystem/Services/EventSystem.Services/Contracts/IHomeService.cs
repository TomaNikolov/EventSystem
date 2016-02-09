namespace EventSystem.Services.Contracts
{
    using System.Linq;

    using EventSystem.Models;

    public interface IHomeService : IService
    {
        IQueryable<Event> GetAllEvents();

        IQueryable<Event> GetTop(int count);
    }
}
