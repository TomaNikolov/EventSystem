namespace EventSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Base;
    using Infrastructure.Extensions;
    using Infrastructure.Populators;
    using Models.Events;
    using Models.PagingAndSorting;
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
            var model = this.eventService.GetById(id)
               .To<EventDetailsViewModel>()
               .FirstOrDefault();

            return this.View(model);
        }

        [PopulatePlaces]
        [PopulateCities]
        [PopulateCountries]
        [PopulateCategories]
        public ActionResult Search(string orderBy, string search, string place, string category, string country, string city, int page = 1)
        {
            page = page < 1 ? 1 : page;

            var model = new EventsPagableAndSortbleViewModel<EventsSearchViewModel>();
            model.Data = this.eventService.GetByPage(page, orderBy, search, place, category, country, city)
            .To<EventsSearchViewModel>()
            .ToList();

            model.AllPage = this.eventService.GetAllPage(page, orderBy, search, place, category, country, city);
            model.BindData(orderBy, search, place, category, country, city, page);

            return this.View(model);
        }
    }
}
