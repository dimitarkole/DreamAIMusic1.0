namespace DreamAIMusic.Web.Controllers.UsersControllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;
    using DreamAIMusic.Web.ViewModels.User.SongReactionModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class CommentReactionController : UserController
    {
        private readonly ICommentReactionService commentReactionService;

        public CommentReactionController(
            ICommentReactionService commentReactionService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
            this.commentReactionService = commentReactionService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CommentReactionCreateModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.commentReactionService.Create(model, userId);
            return this.Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, CommentReactionCreateModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.commentReactionService.Update(model, id);
            return this.Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.commentReactionService.Delete(id);
            return this.Ok();
        }
    }
}
