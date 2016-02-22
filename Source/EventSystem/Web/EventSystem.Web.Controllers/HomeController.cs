namespace EventSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Base;
    using Infrastructure.Extensions;
    using Models.Events;
    using Models.Home;
    using Services.Contracts;

    public class HomeController : BaseController
    {
        private IEventsService eventsService;

        public HomeController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel();

            model.TopEvents = this.eventsService.GetTop()
               .To<EventDetailsViewModel>()
               .ToList();

            model.NewEvents = this.eventsService.GetNew()
                 .To<EventDetailsViewModel>()
               .ToList();
            return this.View(model);
        }
    }
}