namespace EventSystem.Web.Areas.EventMaker
{
    using System.Web.Mvc;

    public class EventMakerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EventMaker";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EventMaker_default",
                "EventMaker/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "EventSystem.Web.Areas.EventMaker.Controllers" });
        }
    }
}