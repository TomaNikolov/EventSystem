namespace EventSystem.Web.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;

    public class OrderController : Controller
    {
        private IHomeService homeService;

        public OrderController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public ActionResult Cart()
        {
            return this.View();
        }
    }
}
