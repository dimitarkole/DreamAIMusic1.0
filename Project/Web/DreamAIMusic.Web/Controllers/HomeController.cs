namespace DreamAIMusic.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels;
    using DreamAIMusic.Web.ViewModels.User.SongModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : ApiController
    {
        private readonly ISongService songService;
        private readonly ISongViewHistoryService songViewHistoryService;

        public HomeController(
            ISongService songService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ISongViewHistoryService songViewHistoryService,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
            this.songService = songService;
            this.songViewHistoryService = songViewHistoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SongViewModel>> Get()
          => this.Ok(this.songService.All<SongViewModel>());

        [HttpGet("{id}")]
        public ActionResult<SongPlayModel> Get(string id)
            => this.Ok(this.songService.GetById<SongPlayModel>(id));
    }
}
