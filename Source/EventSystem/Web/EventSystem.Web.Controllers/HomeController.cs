namespace EventSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Models.Events;
    using Models.Home;
    using Services.Contracts;
    using Infrastructure;
    using AutoMapper.QueryableExtensions;
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
            var bulder = MapperFactory.GetConfig();
            homeViewModel.TopEvents = this.homeService.GetTop(5)
               .ProjectTo<EventDetailsViewModel>(bulder)
               .ToList();

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}