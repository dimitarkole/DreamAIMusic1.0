namespace DreamAIMusic.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamAIMusic.Data.Models;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected readonly UserManager<ApplicationUser> userManager;
        protected readonly SignInManager<ApplicationUser> signInManager;
        protected readonly ILogger<LogoutModel> logger;
        protected readonly IHostingEnvironment hostingEnvironment;

        public ApiController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          ILogger<LogoutModel> logger,
          IHostingEnvironment hostingEnvironment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.hostingEnvironment = hostingEnvironment;
        }
    }
}
