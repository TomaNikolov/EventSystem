namespace EventSystem.Web.Infrastructure.Populators
{
    using System.Web.Mvc;

    using Data.Common.Repositories;
    using Models;
    using Ninject;

    public class PopulatePlacesAttribute : BasePopulator
    {
        private const string Places = "Places";

        [Inject]
        public IDbRepository<Place> PLacesRepository { private get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Countries = base.GetSelecTedList(this.PLacesRepository, Places);
            base.OnActionExecuting(filterContext);
        }
    }
}
