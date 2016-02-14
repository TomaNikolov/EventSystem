namespace EventSystem.Models
{
    using System.Collections.Generic;

    using Data.Common.Models;

    public class Order : BaseModel<int>
    {
        private ICollection<OrderItem> orderItems;

        public Order()
        {
            this.orderItems = new HashSet<OrderItem>();
        }

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
