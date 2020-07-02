namespace DreamAIMusic.Web.Areas.Administration.Controllers
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Data;
    using DreamAIMusic.Web.Areas.Identity.Pages.Account;
    using DreamAIMusic.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger, IHostingEnvironment hostingEnvironment) : base(userManager, signInManager, logger, hostingEnvironment)
        {
            this.settingsService = settingsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }
    }
}
