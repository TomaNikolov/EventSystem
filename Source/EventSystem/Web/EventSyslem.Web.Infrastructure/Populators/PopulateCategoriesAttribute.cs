namespace EventSystem.Web.Infrastructure.Populators
{
    using System.Web.Mvc;

    using Data.Common.Repositories;
    using Models;
    using Ninject;

    public class PopulateCategoriesAttribute : BasePopulator
    {
        private const string Categories = "Categorise";

        [Inject]
        public IDbRepository<Category> CategoriesRepository { private get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Countries = base.GetSelecTedList(this.CategoriesRepository, Categories);
            base.OnActionExecuting(filterContext);
        }
    }
}
