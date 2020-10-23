namespace DreamAIMusic.Web.Controllers.UsersControllers
{
    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.Extensions.Logging;

    [Authorize(Roles = GlobalConstants.Roles.UserRoleName)]
    public class UserController : ApiController
    {
        public UserController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
        }
    }
}
