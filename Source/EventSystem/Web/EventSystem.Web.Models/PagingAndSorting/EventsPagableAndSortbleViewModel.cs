using System.ComponentModel.DataAnnotations;

namespace EventSystem.Web.Models.PagingAndSorting
{
    public class EventsPagableAndSortbleViewModel<T> : PagableAndSortbleViewModel<T>
    {
        [Display(Name = "Place")]
        [UIHint("PlacesDropDown")]
        public string Place { get; set; }

        [Display(Name = "Category")]
        [UIHint("CategoriesDropDown")]
        public string Category { get; set; }

        [Display(Name = "Country")]
        [UIHint("CountriesDropDown")]
        public string Country { get; set; }

        [Display(Name = "City")]
        [UIHint("CitiesDropDown")]
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
