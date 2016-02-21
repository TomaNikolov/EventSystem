namespace EventSystem.Web.Areas.EventMaker.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;

    using Base;
    using EventSystem.Models;
    using Infrastructure.Constants;
    using Infrastructure.Extensions;
    using Infrastructure.Notifications;
    using Infrastructure.Populators;
    using Models.Places;
    using Services.Contracts;
    using Services.Web.Contracts;
  
    public class PlacesController : BaseEventMakerController<PlaceViewModel>
    {
        private IPlacesService placesService;

        private IImagesService imagesService;

        public PlacesController(IPlacesService placesService, IImagesService imagesService)
        {
            this.placesService = placesService;
            this.imagesService = imagesService;
        }

        [HttpGet]
        [PopulateCities]
        [PopulateCountries]
        public ActionResult Create()
        {
            var model = this.GetModel<CreatetPlaceViewModel, Place>(this.placesService, null);

            return this.View(model);
        }

        [HttpGet]
        [PopulateCities]
        [PopulateCountries]
        public ActionResult Edit(int id)
        {
            var model = this.GetModel<CreatetPlaceViewModel, Place>(this.placesService, id);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatetPlaceViewModel model)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var imageIds = this.imagesService.SaveImages(model.Name, model.Files);
            var placeId = this.placesService.Create(model.Name, model.Description, model.CountryId, model.CityId, model.Latitude, model.Longitude, model.Street, imageIds);

            this.AddToastMessage(Messages.Congratulations, Messages.PlaceCreateMessage, ToastType.Success);

            return this.RedirectToAction(x => x.Details(placeId));
        }

        public ActionResult Details(int id)
        {
            return this.View();
        }

        protected override IQueryable<TModel> GetData<TModel>(int page, string orderBy, string search)
        {
            return this.placesService
                .GetByPage(page, orderBy, search)
                 .To<PlaceViewModel>() as IQueryable<TModel>;
        }

        protected override int GetAllPage<TModel>(int page, string orderBy, string search)
        {
            return this.placesService.GetAllPage(page, orderBy, search);
        }
    }
}
