namespace EventSystem.Web.Models.Home
{
    using System.Collections.Generic;

    using Events;

    public class HomeViewModel 
    {
        public ICollection<EventDetailsViewModel> TopEvents { get; set; }
    }
}
