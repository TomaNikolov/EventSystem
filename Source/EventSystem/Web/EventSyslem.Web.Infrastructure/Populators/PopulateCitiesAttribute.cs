namespace EventSystem.Web.Infrastructure.Populators
{
    using System.Web.Mvc;

    using Ninject;
    using Data.Repositories;
    using Models;

    public class PopulateCitiesAttribute : BasePopulator
    {
        [Inject]
        public IRepository<City> Cities { private get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Cities = base.GetSelecTedList(this.Cities);
            base.OnActionExecuting(filterContext);
        }
    }
}
