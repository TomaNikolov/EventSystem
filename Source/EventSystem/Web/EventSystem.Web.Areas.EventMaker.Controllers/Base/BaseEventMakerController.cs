namespace EventSystem.Web.Areas.EventMaker.Controllers.Base
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure;
    using Services.Contracts;
    using Web.Controllers.Base;
    using Models.PagingAndSorting;
    using Infrastructure.Constants;

    [Authorize(Roles = Roles.EventMaker)]
    public abstract class BaseEventMakerController<T> : BaseAuthorizationController
        where T : class
    {
        public BaseEventMakerController(IUsersService usersService)
            : base(usersService)
        {

        }

        public virtual ActionResult All(string orderBy, string search, int page = 1)
        {
            page = page < 1 ? 1 : page;
            var model = new PagableAndSortbleViewModel<T>();
            model.Data = this.GetData<T>(page, orderBy, search)
                .ToList();

            model.Page = page;
            model.Search = search;
            model.OrderBy = orderBy;
            model.AllPage = this.GetAllPage<T>(page, orderBy, search);

            return this.View(model);
        }

        [NonAction]
        protected TModel GetModel<TModel, TEntity>(IAdministrationService<TEntity> adminService, int? id)
            where TModel : new()
            where TEntity : class
        {
            return id.HasValue ? MapperFactory.GetConfig()
                                              .CreateMapper()
                                              .Map<TModel>(adminService.GetById(this.CurrentUser.Id, id)) : new TModel();
        }

        [NonAction]
        protected abstract IQueryable<TModel> GetData<TModel>(int page, string orderBy, string search)
            where TModel : class;

        [NonAction]
        protected abstract int GetAllPage<TModel>(int page, string orderBy, string search)
           where TModel : class;
    }
}
