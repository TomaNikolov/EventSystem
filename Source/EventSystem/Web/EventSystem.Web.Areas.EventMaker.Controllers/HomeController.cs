namespace EventSystem.Web.Areas.EventMaker.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        // GET: EventMaker/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}