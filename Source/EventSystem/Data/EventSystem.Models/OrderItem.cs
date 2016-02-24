namespace EventSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    using EventSystem.Data.Common.Models;

    public class OrderItem : BaseModel<int>
    {
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}