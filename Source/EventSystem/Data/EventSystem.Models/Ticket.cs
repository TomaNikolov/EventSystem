namespace EventSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int Ammount { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}