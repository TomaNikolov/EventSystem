namespace EventSystem.Web.Models.Orders
{
    public class ConfirmOrderViewModel
    {
        public DeliveryAddressViewModel DeliveryAddress { get; set; }

        public ShoppingCartViewModel ShoppingCart { get; set; }
    }
}
