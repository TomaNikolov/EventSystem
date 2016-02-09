namespace EventSystem.Web.Areas.EventMaker.Controllers
{
    using Models.Places;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    public class PlacesController : Controller
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
            // return this.placesService.GetAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new GetCreatePlaceViewModel();
            model.Countries = this.countriesService
                .GetAll()
                .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() })
                .ToList();

            model.Cities = this.citiesService
              .GetAll()
              .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() })
              .ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PostCreatePlaceViewModel model)
        {
            return RedirectToAction("Details");
        }

        public ActionResult Detatils(int id)
        {
            return View();
        }
    }
}
