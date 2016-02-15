namespace EventSystem.Models
{
    using EventSystem.Data.Common.Models;

    public class DeliveryAdress : BaseModel<int>
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}