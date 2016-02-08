namespace EventSystem.Web.Controllers
{
    using AutoMapper;
    using EventSystem.Models;
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
#pragma warning disable CS0618 // Type or member is obsolete
            var viewModel = Mapper.Map<Event, EventDetailsViewModel>(events);
#pragma warning restore CS0618 // Type or member is obsolete
            return View(viewModel);
        }
    }
}
