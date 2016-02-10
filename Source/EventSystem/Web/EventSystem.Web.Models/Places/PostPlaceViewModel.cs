namespace EventSystem.Web.Models.Places
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using EventSystem.Models;
    using Infrastructure.Mappings;
    public class PostPlaceViewModel : IMapFrom<Place>
    {
        [Required]
        [MinLength(2)]
        public string Venue { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }

        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}
