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
    using Services.Web.Contracts;
    using Infrastructure.Constants;

    public class EventsController : BaseEventMakerController<EventViewModel>
    {
        private  IEventsService eventsService;
        private IWebImagesService imagesService;
        private ITicketsService ticketsServices;

        public EventsController(IEventsService eventsService, IWebImagesService imagesService, ITicketsService ticketsServices, IUsersService usersService)
            :base(usersService)
        {
            this.eventsService = eventsService;
            this.imagesService = imagesService;
            this.ticketsServices = ticketsServices;
        }

        [HttpGet]
        [PopulatePlaces]
        [PopulateCategories]
        public ActionResult Create()
        {
            var model = this.GetModel<CreateEventViewModel, Event>(this.eventsService, null);

            return this.View(model);
        }

        [HttpGet]
        [PopulatePlaces]
        [PopulateCategories]
        public ActionResult Edit(int id)
        {
            var model = this.GetModel<CreateEventViewModel, Event>(this.eventsService, id);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEventViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
          
            var imageIds = this.imagesService.SaveImages(model.Title, model.Files);
            var eventId = this.eventsService.Create(this.CurrentUser.Id, model.Title, model.Description, model.EventStart, model.CategoryId, model.PlaceId, imageIds);
            this.ticketsServices.Create(model.Ticket.Price, model.Ticket.Ammount, eventId);
            this.AddToastMessage(Messages.Congratulations, Messages.PlaceCreateMessage, ToastType.Success);

            return this.RedirectToAction(x => x.Details(eventId));
        }

        public ActionResult Details(int id)
        {
            return this.View();
        }

        protected override IQueryable<TModel> GetData<TModel>(int page, string orderBy, string search)
        {
            return this.eventsService
              .GetByPage(this.CurrentUser.Id, page, orderBy, search)
               .To<EventViewModel>() as IQueryable<TModel>;
        }

        protected override int GetAllPage<TModel>(int page, string orderBy, string search)
        {
            return this.eventsService.GetAllPage(this.CurrentUser.Id, page, orderBy, search);
        }
    }
}
