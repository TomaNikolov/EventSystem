namespace EventSystem.Models
{
    using EventSystem.Data.Common.Models;

    public class Notification : BaseModel<int>
    {
        public NotificationType NotificationType { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
