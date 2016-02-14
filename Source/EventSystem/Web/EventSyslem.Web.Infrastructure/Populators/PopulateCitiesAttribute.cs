namespace EventSystem.Web.Infrastructure.Populators
{
    using System.Web.Mvc;

    using Data.Common.Repositories;
    using Models;
    using Ninject;

    public class PopulateCitiesAttribute : BasePopulator
    {
        [Inject]
        public IDbRepository<City> Cities { private get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //filterContext.Controller.ViewBag.Cities = base.GetSelecTedList(this.Cities);
            //base.OnActionExecuting(filterContext);
        }
    }
}
