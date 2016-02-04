namespace EventSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        private ICollection<OrderItem> orderItems;

        public Order()
        {
            this.orderItems = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }

        public int DeliveryAdressId { get; set; }

        public virtual DeliveryAdress DeliveryAdress { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public ICollection<OrderItem> OrderItems
        {
            get { return this.orderItems; }
            set { this.orderItems = value; }
        }
    }
}
