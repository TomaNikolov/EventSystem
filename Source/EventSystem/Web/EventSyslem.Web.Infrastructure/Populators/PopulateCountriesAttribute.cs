namespace EventSystem.Web.Infrastructure.Populators
{
    using System.Web.Mvc;

    using Data.Common.Repositories;
    using Models;
    using Ninject;

    public class PopulateCountriesAttribute : BasePopulator
    {
        [Inject]
        public IDbRepository<Country> Countries { private get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //filterContext.Controller.ViewBag.Countries = base.GetSelecTedList(this.Countries);
            //base.OnActionExecuting(filterContext);
        }
    }
}
