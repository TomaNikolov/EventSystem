namespace EventSystem.Web.Controllers.Base
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using EventSystem.Models;
    using EventSystem.Services.Contracts;

    [Authorize]
    public class BaseAuthorizationController : BaseController
    {
        private readonly IUsersService usersService;

        public BaseAuthorizationController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        protected User CurrentUser { get; private set; }

        protected override System.IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, System.AsyncCallback callback, object state)
        {
            if (CurrentUser == null && this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.Identity.GetUserId();

                this.CurrentUser = this.usersService.GetById(userId);
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}
