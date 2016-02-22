namespace EventSystem.Web.Models.PagingAndSorting
{
    public class EventsPagableAndSortbleViewModel<T> : PagableAndSortbleViewModel<T>
    {
        public string Place { get; set; }

        public string Category { get; set; }

        public string Country { get; set; }

        public string City { get; set; }


        public void BindData(string orderby, string search, string place, string catogory, string country, string city, int page)
        {
            this.Page = page;
            this.Place = place;
            this.Search = search;
            this.OrderBy = orderby;
            this.City = city;
            this.Country = country;
        }
    }
}
