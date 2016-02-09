namespace EventSystem.Web.Models.Places
{
    using DropDownList;
    using System.ComponentModel.DataAnnotations;

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
