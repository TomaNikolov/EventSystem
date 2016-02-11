namespace EventSystem.Web.Controllers.Base
{
    using System.Web.Mvc;

    using AutoMapper;
    using Infrastructure;

    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Config = MapperFactory.GetConfig();
        }

        protected MapperConfiguration Config { get; set; }
    }
}
