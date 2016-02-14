namespace EventSystem.Web.Controllers
{
    using Infrastructure.Extensions;
    using Models.Events;
    using Models.Home;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public ActionResult Index()
        {
            var homeViewModel = new HomeViewModel();

            homeViewModel.TopEvents = this.homeService.GetTop(5)
               .To<EventDetailsViewModel>()
               .ToList();

            return this.View(homeViewModel);
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}