namespace DreamAIMusic.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels;
    using DreamAIMusic.Web.ViewModels.UserModels.MusicModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : ApiController
    {
        private readonly ISongService songService;

        public HomeController(
            ISongService songService,
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger, 
            IHostingEnvironment hostingEnvironment) 
            : base(userManager, signInManager, logger, hostingEnvironment)
        {
            this.songService = songService;
        }

        [Authorize]
        [Route(nameof(Index))]
        [HttpGet]
        public IActionResult Index()
        {
            // var musics = this.songService.All<SongViewModel>();
            return this.Ok("Works Index");
        }

        [Route(nameof(Privacy))]
        [HttpGet]
        public IActionResult Privacy()
        {
            return this.Ok("Works Privacy");

        }

        [Route(nameof(Error))]
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.Ok("Works Error");

            /*
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });*/
        }
    }
}
