namespace EventSystem.Web.Areas.EventMaker.Controllers.Base
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Contracts;
    using Web.Controllers.Base;

    public abstract class BaseEventMakerController<T> : BaseController
        where T : class
    {
        public virtual ActionResult All(int count = 10, int page = 1)
        {
            var result = this.GetData<T>(count, page)
                .ToList();

            return this.View(result);
        }

        public virtual ActionResult Details(int id)
        {
            return this.View();
        }

        [NonAction]
        protected TModel GetModel<TModel, TEntity>(IAdministrationService<TEntity> adminService, int? id)
            where TModel : new()
            where TEntity : class
        {
            return id.HasValue ? this.Config.CreateMapper().Map<TModel>(adminService.GetById(id)) : new TModel();
        }

        [NonAction]
        protected abstract IQueryable<TModel> GetData<TModel>(int count, int page)
            where TModel : class;
    }
}
