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
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class CommentDislikeController : ApiController
    {
        private readonly ICommentDislikeService commentDislikeService;

        public CommentDislikeController(
            ICommentDislikeService commentDislikeService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger,
            IHostingEnvironment hostingEnvironment)
            : base(userManager, signInManager, logger, hostingEnvironment)
        {
            this.commentDislikeService = commentDislikeService;
        }

        [HttpGet]
        public ActionResult GetCount(string commentarId)
          => this.Ok(this.commentDislikeService.Count(commentarId));

        [HttpPost]
        [Authorize(Roles = GlobalConstants.UserRoleName)]
        public async Task<IActionResult> Post(CommentDislikeInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.commentDislikeService.Create(model, userId);
            return this.Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = GlobalConstants.UserRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            await this.commentDislikeService.Delete(id);
            return this.Ok();
        }
    }
}
