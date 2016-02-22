namespace EventSystem.Web.Infrastructure.Extensions
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ForPublicEventsDropDown(this IEnumerable<SelectListItem> selectListItems)
        {
           
            foreach (var item in selectListItems)
            {
                item.Value = item.Text;
            }

            return selectListItems;
        }
    }
}
