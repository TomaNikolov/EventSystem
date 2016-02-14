namespace EventSystem.Web.Infrastructure.Populators
{
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Data.Common.Models;
    using EventSystem.Data.Common.Repositories;
    using Extensions;
    using Ninject;

    public class BasePopulator : ActionFilterAttribute
    {
        [Inject]
        public ICacheService CacheService { private get; set; }

        protected IEnumerable<SelectListItem> GetSelecTedList<T, TKey>(IDbRepository<T, TKey> repository, string itemName)
            where T : BaseModel<TKey>, IListedItem
        {
            var result = this.CacheService.Get(
                itemName,
                () => repository.All().To<SelectListItem>().ToList(),
                60 * 60);

            return result;
        }
    }
}
