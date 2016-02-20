namespace EventSystem.Web.Models.Places
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using EventSystem.Models;
    using Infrastructure.Mappings;

    public class CreatetPlaceViewModel : IMapFrom<Place>
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Display(Name = "Country")]
        [UIHint("CountriesDropDown")]
        public int CountryId { get; set; }

        [Display(Name = "City")]
        [UIHint("CitiesDropDownList")]
        public int CityId { get; set; }

        [UIHint("FileUpload")]
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [DataType(DataType.MultilineText)]
        [UIHint("TextArea")]
        public string Description { get; set; }
    }
}
