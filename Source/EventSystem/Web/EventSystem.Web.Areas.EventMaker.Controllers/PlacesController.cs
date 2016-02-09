namespace EventSystem.Web.Areas.EventMaker.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Models.Places;
    using Services.Contracts;
      using Web.Controllers.Base;

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
        public ActionResult Create()
        {
            var model = new PostCreatePlaceViewModel();

            model.Countries.Items = this.countriesService
                .GetAll()
                .ProjectTo<SelectListItem>(this.config)
                .ToList();

            model.Cities.Items = this.citiesService
              .GetAll()
              .ProjectTo<SelectListItem>(this.config)
              .ToList();

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(PostCreatePlaceViewModel model)
        {
            return this.RedirectToAction("Details");
        }

        public ActionResult Detatils(int id)
        {
            return this.View();
        }
    }
}
