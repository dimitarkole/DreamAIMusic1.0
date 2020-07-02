namespace DreamAIMusic.Web.Areas.User.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Web.Areas.Identity.Pages.Account;
    using DreamAIMusic.Web.Controllers;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class UserController : BaseController
    {
        protected readonly UserManager<ApplicationUser> userManager;
        protected readonly SignInManager<ApplicationUser> signInManager;
        protected readonly ILogger<LogoutModel> logger;
        protected readonly IHostingEnvironment hostingEnvironment;
        protected readonly string userId;
        public UserController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          ILogger<LogoutModel> logger,
          IHostingEnvironment hostingEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.hostingEnvironment = hostingEnvironment;
            //this.userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
