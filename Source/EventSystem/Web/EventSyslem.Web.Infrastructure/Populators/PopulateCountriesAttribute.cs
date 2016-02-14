namespace EventSystem.Web.Infrastructure.Populators
{
    using System.Web.Mvc;

    using Data.Common.Repositories;
    using Models;
    using Ninject;

    public class PopulateCountriesAttribute : BasePopulator
    {
        private const string Countries = "Countries";

        [Inject]
        public IDbRepository<Country> CountriesRepository { private get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Countries = base.GetSelecTedList(this.CountriesRepository, Countries);
            base.OnActionExecuting(filterContext);
        }
    }
}
