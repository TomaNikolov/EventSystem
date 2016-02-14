namespace EventSystem.Models
{
    using EventSystem.Data.Common.Models;

    public class Ticket : BaseModel<int>
    {
        public decimal Price { get; set; }

        public int Ammount { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}