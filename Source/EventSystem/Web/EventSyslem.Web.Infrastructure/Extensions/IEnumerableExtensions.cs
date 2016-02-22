namespace EventSystem.Web.Infrastructure.Extensions
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ForPublicEventsDropDown(this IEnumerable<SelectListItem> selectList)
        {
            foreach (var item in selectList)
            {
                item.Value = item.Text;
            }

            return selectList;
        }
    }
}
