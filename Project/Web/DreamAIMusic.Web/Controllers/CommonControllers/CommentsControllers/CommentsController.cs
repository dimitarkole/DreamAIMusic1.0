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

    public class CommentsController : ApiController
    {
        private readonly ICommentService commentService;

        public CommentsController(
            ICommentService commentService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger,
            IHostingEnvironment hostingEnvironment)
            : base(userManager, signInManager, logger, hostingEnvironment)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommentViewModel>> Get(string musicId)
           => this.Ok(this.commentService.All<CommentViewModel>(musicId));

        [HttpPost]
        [Authorize(Roles = GlobalConstants.UserRoleName)]
        public async Task<IActionResult> Post(CommentInputModel model, string songId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.commentService.Create(model, songId, userId);
            return this.Ok();
        }

        [HttpPost]
        // [Authorize(Roles = GlobalConstants.UserRoleName)]
        [Route("[action]")]
        public async Task<IActionResult> PostChildrenCommentar(CommentInputModel model, string parentCommentId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.commentService.CreateChildrenComment(model, parentCommentId, userId);
            return this.Ok();
        }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, CommentEditModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.commentService.Update(id, model);
            return this.Ok();
        }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.commentService.Delete(id);
            return this.Ok();
        }
    }
}
