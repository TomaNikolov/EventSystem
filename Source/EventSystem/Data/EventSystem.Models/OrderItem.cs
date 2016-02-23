namespace EventSystem.Models
{
    using EventSystem.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class OrderItem : BaseModel<int>
    {
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}