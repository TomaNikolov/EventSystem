namespace EventSystem.Web.Controllers.Base
{
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using EventSystem.Models;
    using EventSystem.Services.Contracts;

    [Authorize]
    public class BaseAuthorizationController : BaseController
    {
        private IUsersService usersService;
        private User currentUser;

        public BaseAuthorizationController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        protected User CurrentUser
        {
            get
            {
                if (this.currentUser == null && this.User.Identity.IsAuthenticated)
                {
                    var userId = this.User.Identity.GetUserId();

                    this.currentUser = this.usersService.GetById(userId);
                }

                return this.currentUser;
            }
        }
    }
}
