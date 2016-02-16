namespace EventSystem.Web.Controllers
{
    using Services.Web.Contracts;
    using System.Web.Mvc;

    public class OrderController : Controller
    {
        private IShoppingCartService shoppingCartService;

        public OrderController(IShoppingCartService shoppingCartService)
        {
            this.shoppingCartService = shoppingCartService;
        }

        public ActionResult Cart()
        {
            var model = this.
            return this.View();
        }
    }
}
