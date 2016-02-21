namespace EventSystem.Web.Models.PagingAndSorting
{
    using System.Collections.Generic;

    public class PagableAndSortbleViewModel<T> : IPagableAndSortble<T>
    {
        public int AllPage { get; set; }

        public string OrderBy { get; set; }

        public int Page { get; set; }

        public string Search { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
