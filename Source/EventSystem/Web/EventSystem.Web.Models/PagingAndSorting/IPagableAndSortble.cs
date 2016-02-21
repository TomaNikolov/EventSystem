
namespace EventSystem.Web.Models.PagingAndSorting
{
    using System.Collections.Generic;

    public interface IPagableAndSortble<T>
    {
        string OrderBy { get; set; }

        string Search { get; set; }

        int Page { get; set; }

        int AllPage { get; set; }

        IEnumerable<T> Data { get; set; }
    }
}
