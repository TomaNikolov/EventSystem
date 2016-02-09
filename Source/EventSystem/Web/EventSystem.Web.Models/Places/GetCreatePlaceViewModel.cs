namespace EventSystem.Web.Models.Places
{
    using EventSystem.Web.Models.DropDownList;

    public class GetCreatePlaceViewModel
    {
        public string Venue { get; set; }

        public DropDownViewModel Countries { get; set; }

        public DropDownViewModel Cities { get; set; }
    }
}
