namespace EventSystem.Web.Areas.EventMaker.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using EventSystem.Web.Areas.EventMaker.Controllers.Base;
    using Infrastructure.Populators;
    using Models.Events;
    using Services.Contracts;
    using Infrastructure.Extensions;
    using Infrastructure.Notifications;
    using EventSystem.Models;

    public class EventsController : BaseEventMakerController<EventViewModel>
    {
        private readonly IEventsService eventssService;

        private IImagesService imagesService;

        public EventsController(IEventsService eventssService, IImagesService imagesService)
        {
            this.eventssService = eventssService;
            this.imagesService = imagesService;
        }

        [HttpGet]
        [PopulatePlaces]
        public ActionResult Create()
        {
            var model = this.GetModel<CreateEventViewModel, Event>(this.eventssService, null);

            return this.View(model);
        }

        [HttpGet]
        [PopulatePlaces]
        public ActionResult Edit(int id)
        {
            var model = this.GetModel<CreateEventViewModel, Event>(this.eventssService, id);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateEventViewModel model)
        {
          //  this.imagesService.SaveImages(model.Files);
            this.AddToastMessage("Congratulations", "You made it all the way here!", ToastType.Success);
            return this.RedirectToAction(x => x.Details(2));
        }

        public ActionResult Details(int id)
        {
            return this.View();
        }

        protected override IQueryable<TModel> GetData<TModel>(int count, int page)
        {
            return this.eventssService
               .GetAll()
                .To<EventViewModel>() as IQueryable<TModel>;
        }
    }
}
