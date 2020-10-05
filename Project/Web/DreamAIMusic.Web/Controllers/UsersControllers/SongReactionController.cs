using DreamAIMusic.Data.Models;
using DreamAIMusic.Services.Contracts.User;
using DreamAIMusic.Web.ViewModels.User.SongReactionModels;
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
    public class SongReactionController : UserController
    {
        private readonly ISongReactionService songReactionService;

        public SongReactionController(
            ISongReactionService songReactionService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
            this.songReactionService = songReactionService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(SongReactionCreateModel model)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.songReactionService.Create(model, userId);
            return this.Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, SongReactionCreateModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.songReactionService.Update(model, id);
            return this.Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.songReactionService.Delete(id);
            return this.Ok();
        }
    }
}
