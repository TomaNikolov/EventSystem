namespace EventSystem.Web.Models.Places
{
    using System.ComponentModel.DataAnnotations;

    public class PostCreatePlaceViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Venue { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }
    }
}
