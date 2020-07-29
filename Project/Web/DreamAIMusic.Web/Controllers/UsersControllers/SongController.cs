namespace DreamAIMusic.Web.Controllers.UsersControllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels.UserModels.SongModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class SongController : UserController
    {
        private readonly ISongService songService;

        public SongController(
            ISongService songService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger,
            IHostingEnvironment hostingEnvironment)
            : base(userManager, signInManager, logger, hostingEnvironment)
        {
            this.songService = songService;
        }

        [HttpGet]
        [Route(nameof(Get))]
        public ActionResult<IEnumerable<SongViewModel>> Get()
            => this.Ok(this.songService.All<SongViewModel>());

        [HttpGet]
        [Route(nameof(GetOwn))]
        [Authorize(Roles = GlobalConstants.UserRoleName)]
        public ActionResult<IEnumerable<SongViewModel>> GetOwn()
            => this.Ok(this.songService.AllOwn<SongViewModel>(this.userManager.GetUserId(this.User)));

        [HttpGet("{id}")]
        public ActionResult<SongViewModel> Get(string id) =>
            this.Ok(this.songService.GetById<SongViewModel>(id));

        [HttpPost]
        [Route(nameof(Post))]
        [Authorize(Roles = GlobalConstants.UserRoleName)]
        public async Task<IActionResult> Post(SongInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.songService.Create(model, userId);
            return this.StatusCode(StatusCodes.Status201Created);
        }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, SongEditModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (this.songService.IsOwn(id, userId))
            {
                return this.StatusCode(StatusCodes.Status406NotAcceptable);
            }

            await this.songService.Update(id, model);
            return this.Ok();
        }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            if (this.songService.IsOwn(id, userId))
            {
                return this.StatusCode(StatusCodes.Status406NotAcceptable);
            }

            await this.songService.Delete(id);
            return this.Ok();
        }
    }
}
