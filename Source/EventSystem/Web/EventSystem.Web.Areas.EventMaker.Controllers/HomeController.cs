namespace EventSystem.Web.Areas.EventMaker.Controllers
{
    using System.Web.Mvc;

    using Services.Contracts;
    using Web.Controllers.Base;

    public class HomeController : BaseAuthorizationController
    {
        public HomeController(IUsersService usersService)
            :base(usersService)
        {

        }
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
