namespace EventSystem.Web.Areas.EventMaker.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Models.Places;
    using Services.Contracts;
    using Web.Controllers.Base;
    using Infrastructure.Populators;
    public class PlacesController : BaseController
    {
        private ICountriesService countriesService;

        private ICitiesService citiesService;

        public PlacesController(ICountriesService countriesService, ICitiesService citiesService)
        {
            this.countriesService = countriesService;
            this.citiesService = citiesService;
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
            return this.RedirectToAction("Details");
        }

        public ActionResult Detatils(int id)
        {
            return this.View();
        }
    }
}
