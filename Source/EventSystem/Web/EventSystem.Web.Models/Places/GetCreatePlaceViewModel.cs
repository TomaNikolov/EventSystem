using System.Collections.Generic;
using System.Web.Mvc;

namespace EventSystem.Web.Models.Places
{
    public class GetCreatePlaceViewModel
    {
        public string Venue { get; set; }

        public List<SelectListItem> Countries { get; set; }

        public List<SelectListItem> Cities { get; set; }
    }
}
