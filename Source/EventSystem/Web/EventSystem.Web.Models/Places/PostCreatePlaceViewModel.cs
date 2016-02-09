namespace EventSystem.Web.Models.Places
{
    using System.ComponentModel.DataAnnotations;

    using DropDownList;

    public class PostCreatePlaceViewModel
    {
        public PostCreatePlaceViewModel()
        {
            this.Countries = new DropDownViewModel();
            this.Cities = new DropDownViewModel();
        }

        [Required]
        [MinLength(2)]
        public string Venue { get; set; }

        public DropDownViewModel Countries { get; set; }

        public DropDownViewModel Cities { get; set; }
    }
}
