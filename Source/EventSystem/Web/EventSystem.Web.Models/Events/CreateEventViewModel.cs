namespace EventSystem.Web.Models.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class CreateEventViewModel
    {
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

        public int CategoryId { get; set; }

        public virtual ICollection<HttpPostedFileBase> Images { get; set; }

        public ICollection<TicketViewModel> Tickets { get; set; }
    }
}
