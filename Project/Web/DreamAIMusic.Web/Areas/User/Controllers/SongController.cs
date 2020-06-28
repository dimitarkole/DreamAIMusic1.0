namespace DreamAIMusic.Web.Areas.User.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.Areas.Identity.Pages.Account;
    using DreamAIMusic.Web.Controllers;
    using DreamAIMusic.Web.ViewModels.UserModels.MusicModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Authorize(Roles = GlobalConstants.UserRoleName)]
    [Area("User")]
    public class SongController : UserController
    {
        private readonly ISongService musicService;

        public SongController(
            ISongService musicService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger,
            IHostingEnvironment hostingEnvironment)
            : base(userManager, signInManager, logger, hostingEnvironment)
        {
            this.musicService = musicService;
        }

        [HttpGet]
        // [Route("/Music/Create")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SongInputModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            this.ViewData["message"] = await this.musicService.Create(model, userId);
            return this.View(model);
        }
    }
}