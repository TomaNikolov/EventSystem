namespace EventSystem.Web.Controllers
{
    using System.Web.Mvc;

    using Base;
    using EventSystem.Models;
    using Infrastructure;
    using Models.Events;
    using Services.Contracts;
    using Models.PagingAndSorting;
    using Infrastructure.Extensions;
    using System.Linq;
    using Infrastructure.Populators;
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

        [PopulatePlaces]
        [PopulateCities]
        [PopulateCountries]
        [PopulateCategories]
        public ActionResult Search(string orderBy, string search, string place, string catogory, string country, string city, int page = 1)
        {
            page = page < 1 ? 1 : page;

            var model = new EventsPagableAndSortbleViewModel<EventsSearchViewModel>();
            model.Data = this.eventService.GetByPage(page, orderBy, search, place, catogory, country, city)
            .To<EventsSearchViewModel>()
            .ToList();

            model.AllPage = this.eventService.GetAllPage(page, orderBy, search, place, catogory, country, city);
            model.BindData(orderBy, search, place, catogory, country, city, page);

            return this.View(model);
        }
    }
}
