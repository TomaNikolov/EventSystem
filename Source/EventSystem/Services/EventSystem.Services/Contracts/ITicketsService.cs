namespace EventSystem.Services.Contracts
{
    using System.Linq;

    using EventSystem.Models;

    public interface ITicketsService
    {
        IQueryable<Ticket> GetById(int id);
    }
}
