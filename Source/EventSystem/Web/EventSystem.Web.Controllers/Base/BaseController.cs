﻿namespace EventSystem.Web.Controllers.Base
{
    using AutoMapper;
    using Infrastructure;
    using Infrastructure.Constants;
    using System.Web;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected IMapper Mapper
        {
            get
            {
                return MapperFactory.GetConfig().CreateMapper();
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            //if (filterContext.ExceptionHandled)
            //{
            //    return;
            //}

            //if (this.Request.IsAjaxRequest())
            //{
            //    var exception = filterContext.Exception as HttpException;

            //    if (exception != null)
            //    {
            //        this.Response.StatusCode = exception.GetHttpCode();
            //        this.Response.StatusDescription = exception.Message;
            //    }
            //}
            //else
            //{
            //    var controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            //    var actionName = ControllerContext.RouteData.Values["action"].ToString();
            //    this.View(Views.Errors, new HandleErrorInfo(filterContext.Exception, controllerName, actionName)).ExecuteResult(this.ControllerContext);
            //}

            //filterContext.ExceptionHandled = true;
        }
    }
}
