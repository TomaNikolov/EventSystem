namespace EventSystem.Services.Contracts
{
    using EventSystem.Models;

    public interface INotificationsService
    {
        void Create(int eventId, NotificationType notificationType);
    }
}
