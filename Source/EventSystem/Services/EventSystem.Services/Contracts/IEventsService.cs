namespace EventSystem.Services.Contracts
{
    using System.Linq;
    using EventSystem.Models;

    public interface IEventsService : IService
    {
        Event GetById(int id);
    }
}
