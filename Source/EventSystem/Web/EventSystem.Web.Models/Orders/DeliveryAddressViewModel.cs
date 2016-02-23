namespace EventSystem.Web.Models.Orders
{
    using EventSystem.Models;
    using EventSystem.Web.Infrastructure.Mappings;

    public class DeliveryAddressViewModel : IMapFrom<DeliveryAddress>
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostCode { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
