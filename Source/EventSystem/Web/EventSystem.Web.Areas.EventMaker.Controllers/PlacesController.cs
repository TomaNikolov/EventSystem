namespace EventSystem.Web.Areas.EventMaker.Controllers
{
    using System.Web.Mvc;

    using Infrastructure.Populators;
    using Models.Places;
    using Services.Contracts;
    using Web.Controllers.Base;

    public class PlacesController : BaseController
    {
        private ICountriesService countriesService;

        private ICitiesService citiesService;

        private IImagesService imagesService;

        public PlacesController(ICountriesService countriesService, ICitiesService citiesService, IImagesService imagesService)
        {
            this.countriesService = countriesService;
            this.citiesService = citiesService;
            this.imagesService = imagesService;
        }

        public ActionResult All()
        {
            return this.View();
        }

        [HttpGet]
        [PopulateCities]
        [PopulateCountries]
        public ActionResult Create()
        {
            var model = new PostPlaceViewModel();
            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(PostPlaceViewModel model)
        {
            this.imagesService.SaveImages(model.Files);
            return this.RedirectToAction("Details");
        }

        public ActionResult Detatils(int id)
        {
            return this.View();
        }
    }
}
