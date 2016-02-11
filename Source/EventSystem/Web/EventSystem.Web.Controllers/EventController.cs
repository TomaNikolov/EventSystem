namespace EventSystem.Web.Controllers
{
    using AutoMapper;
    using EventSystem.Models;
    using Infrastructure;
    using Models.Events;
    using Services.Contracts;
    using System.Web.Mvc;

    public class EventController : Controller
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
