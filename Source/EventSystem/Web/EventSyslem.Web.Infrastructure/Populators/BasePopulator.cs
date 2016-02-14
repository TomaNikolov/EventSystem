namespace EventSystem.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using EventSystem.Data.Common;
    using EventSystem.Data.Common.Repositories;
    using Ninject;
    using Services.Contracts;
    using Data.Common.Models;
    public class BasePopulator : ActionFilterAttribute
    {
        [Inject]
        public ICacheService CacheService { private get; set; }

        protected IEnumerable<SelectListItem> GetSelecTedList<T, TKey>(IDbRepository<T, TKey> repository, string itemName)
            where T : BaseModel<TKey>, IListedItem
        {
            var config = MapperFactory.GetConfig();
            var result = this.CacheService.Get(
                itemName,
                () => repository.All().ProjectTo<SelectListItem>(config).ToList(),
                60 * 60);

            return result;
        }
    }
}
