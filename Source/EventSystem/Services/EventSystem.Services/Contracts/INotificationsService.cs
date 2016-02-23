using EventSystem.Models;

namespace EventSystem.Services.Contracts
{
    public interface INotificationsService
    {
        void Create(int eventId, NotificationType notificationType);
    }
}
