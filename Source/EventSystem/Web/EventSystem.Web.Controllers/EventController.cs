namespace EventSystem.Web.Controllers
{
    using System.Web.Mvc;

    using Base;
    using EventSystem.Models;
    using Infrastructure;
    using Models.Events;
    using Services.Contracts;

    public class EventController : BaseController
    {
        private IEventsService eventService;

        public EventController(IEventsService eventService)
        {
            this.eventService = eventService;
        }

        public ActionResult Details(int id)
        {
            var events = this.eventService.GetById(id);
            var viewModel = MapperFactory
                .GetConfig()
                .CreateMapper()
                .Map<Event, EventDetailsViewModel>(events);

            return this.View(viewModel);
        }
    }
}
