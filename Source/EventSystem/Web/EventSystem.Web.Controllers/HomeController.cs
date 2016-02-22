namespace EventSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Base;
    using Infrastructure.Extensions;
    using Models.Events;
    using Models.Home;
    using Services.Contracts;
   
    public class HomeController : BaseController
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
    }
}