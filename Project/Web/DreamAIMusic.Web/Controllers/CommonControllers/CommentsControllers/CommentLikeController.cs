namespace DreamAIMusic.Web.Controllers.CommonControllers.CommentsControllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.Common;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class CommentLikeController : ApiController
    {
        private readonly ICommentLikeService commentLikeService;

        public CommentLikeController(
            ICommentLikeService commentLikeService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
            this.commentLikeService = commentLikeService;
        }

        [HttpGet]
        public ActionResult GetCount(string commentarId)
          => this.Ok(this.commentLikeService.Count(commentarId));

        [HttpPost]
        [Authorize(Roles = GlobalConstants.UserRoleName)]
        public async Task<IActionResult> Post(CommentLikeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.commentLikeService.Create(model, userId);
            return this.Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = GlobalConstants.UserRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            await this.commentLikeService.Delete(id);
            return this.Ok();
        }
    }
}
