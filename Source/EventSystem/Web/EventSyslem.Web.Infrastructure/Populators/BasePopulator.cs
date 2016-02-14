namespace EventSystem.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using EventSystem.Data.Common;
    using EventSystem.Data.Common.Repositories;

    public class BasePopulator : ActionFilterAttribute
    {
        //protected IEnumerable<SelectListItem> GetSelecTedList<TModel>(IDbRepository<TModel> repooitory) 
        //    where TModel : class, IListedItem
        //{
        //    var config = MapperFactory.GetConfig();
        //    var result = repooitory.All();
        //    return result.ProjectTo<SelectListItem>(config).ToList();
        //}
    }
}
