namespace DreamAIMusic.Web.Controllers.CommonControllers.CommentsControllers
{
    using System.Collections.Generic;
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

    public class CommentsController : ApiController
    {
        private readonly ICommentService commentService;

        public CommentsController(
            ICommentService commentService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommentViewModel>> Get(string musicId)
           => this.Ok(this.commentService.All<CommentViewModel>(musicId));

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = GlobalConstants.Roles.UserRoleName)]
        public async Task<IActionResult> Post(CommentInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.commentService.Create(model, userId);
            return this.Ok();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.Roles.UserRoleName)]
        [Route("[action]/$parentCommentId")]
        public async Task<IActionResult> PostChildrenCommentar(CommentEditModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(this.User);

            await this.commentService.CreateChildrenComment(model, userId);
            return this.Ok();
        }

        [Authorize(Roles = GlobalConstants.Roles.UserRoleName)]
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

        [Authorize(Roles = GlobalConstants.Roles.UserRoleName)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.commentService.Delete(id);
            return this.Ok();
        }
    }
}
