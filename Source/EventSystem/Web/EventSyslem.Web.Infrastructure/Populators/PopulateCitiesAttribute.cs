namespace EventSystem.Web.Infrastructure.Populators
{
    using System.Web.Mvc;

    using Data.Common.Repositories;
    using Models;
    using Ninject;
    using Services.Contracts;

    public class PopulateCitiesAttribute : BasePopulator
    {
        private const string Cities = "Cities";

        [Inject]
        public IDbRepository<City> CitiesRepository { private get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Cities = base.GetSelecTedList(this.CitiesRepository, Cities);
            base.OnActionExecuting(filterContext);
        }
    }
}
