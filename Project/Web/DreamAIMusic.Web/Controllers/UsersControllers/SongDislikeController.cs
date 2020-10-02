using DreamAIMusic.Common;
using DreamAIMusic.Data.Models;
using DreamAIMusic.Services.Contracts.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamAIMusic.Web.Controllers.UsersControllers
{
    public class SongDislikeController : UserController
    {
        private readonly ISongDislikeService songDislikeService;

        public SongDislikeController(
            ISongDislikeService songDislikeService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
            this.songDislikeService = songDislikeService;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = GlobalConstants.UserRoleName)]
        public IActionResult GetCount(string id)
            => this.Ok(this.songDislikeService.Count(id));

        [HttpPost]
        [Authorize(Roles = GlobalConstants.UserRoleName)]
        public async Task<IActionResult> Post(string songId)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.songDislikeService.Create(songId, userId);
            return this.Ok();
        }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.songDislikeService.Delete(id);
            return this.Ok();
        }
    }
}
