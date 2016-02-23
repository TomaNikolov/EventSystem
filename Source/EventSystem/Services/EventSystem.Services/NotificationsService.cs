namespace EventSystem.Services
{
    using Data.Common.Repositories;
    using EventSystem.Services.Contracts;
    using Models;

    public class NotificationsService : INotificationsService
    {
        private IDbRepository<Notification> notifications;

        public NotificationsService(IDbRepository<Notification> notifications)
        {
            this.notifications = notifications;
        }

        public void Create(int eventId, NotificationType notificationType)
        {
            var notification = new Notification()
            {
                NotificationType = notificationType,
                EventId = eventId
            };

            this.notifications.Add(notification);
            this.notifications.Save();
        }
    }
}
