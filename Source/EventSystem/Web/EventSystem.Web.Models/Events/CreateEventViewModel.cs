namespace EventSystem.Web.Models.Events
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using Tickets;

    public class CreateEventViewModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        [UIHint("TextArea")]
        public string Description { get; set; }

        [Display(Name = "Event start")]
        [UIHint("DateTime")]
        public DateTime EventStart { get; set; }

        [Display(Name = "Place")]
        [UIHint("PlacesDropDown")]
        public int PlaceId { get; set; }

        [Display(Name = "Category")]
        [UIHint("CategoriesDropDown")]
        public int CategoryId { get; set; }

        [UIHint("FileUpload")]
        public virtual ICollection<HttpPostedFileBase> Files { get; set; }

        [UIHint("Ticket")]
        public CreateTicketViewModel Ticket { get; set; }
    }
}
