namespace EventSystem.Web.Models.Places
{
    using System.ComponentModel.DataAnnotations;

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
    }
}
