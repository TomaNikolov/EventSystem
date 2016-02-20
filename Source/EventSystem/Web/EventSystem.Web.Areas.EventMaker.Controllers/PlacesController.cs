namespace EventSystem.Web.Areas.EventMaker.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Mvc.Expressions;
   
    using Base;
    using EventSystem.Models;
    using Infrastructure.Populators;
    using Models.Places;
    using Services.Contracts;
    using Infrastructure.Notifications;
    using Infrastructure.Extensions;
  
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
            this.imagesService.SaveImages(model.Files);
            this.AddToastMessage("Congratulations", "You made it all the way here!", ToastType.Success);
            return this.RedirectToAction(x => x.Details(2));
        }

        public ActionResult Details(int id)
        {
            return this.View();
        }

        protected override IQueryable<TModel> GetData<TModel>(int count, int page)
        {
            return this.placesService
                .GetAll()
                 .To<PlaceViewModel>() as IQueryable<TModel>;
        }
    }
}
