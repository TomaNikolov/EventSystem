namespace EventSystem.Web.Controllers
{
    using EventSystem.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Models.Events;
    using Models.Home;
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
               .ProjectTo<EventDetailsViewModel>()
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