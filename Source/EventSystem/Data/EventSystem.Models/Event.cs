namespace EventSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data.Common.Models;

    public class Event : BaseModel<int>
    {
        private ICollection<Image> images;
        private ICollection<Ticket> tickets;
        private ICollection<Comment> comments;
        private ICollection<Notification> notifications;

        public Event()
        {
            this.images = new HashSet<Image>();
            this.tickets = new HashSet<Ticket>();
            this.Comments = new HashSet<Comment>();
            this.notifications = new HashSet<Notification>();
        }

        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        public string Description { get; set; }

        public DateTime EventStart { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public ICollection<Ticket> Tickets
        {
            get { return this.tickets; }
            set { this.tickets = value; }
        }

        public ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public ICollection<Notification> Notifications
        {
            get { return this.notifications; }
            set { this.notifications = value; }
        }
    }
}
