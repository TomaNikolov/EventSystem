namespace EventSystem.Web.Areas.EventMaker.Controllers
{
    using Models.Places;
    using System.Web.Mvc;

    public class PlacesController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
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
