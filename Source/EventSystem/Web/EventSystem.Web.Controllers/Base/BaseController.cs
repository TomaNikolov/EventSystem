namespace EventSystem.Web.Controllers.Base
{
    using AutoMapper;
    using Infrastructure;
    using System.Web.Mvc;

    public class BaseController :Controller
    {
        protected MapperConfiguration config;

        public BaseController()
        {
            this.config = MapperFactory.GetConfig();
        }
    }
}
