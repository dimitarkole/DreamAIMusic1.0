namespace DreamAIMusic.Web.Controllers.UsersControllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels.User.SongModels;
    using DreamAIMusic.Web.ViewModels.User.SongViewHistoryModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class SongViewHistoryController : UserController
    {
        private readonly ISongViewHistoryService songViewHistoryService;

        public SongViewHistoryController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger,
            ISongViewHistoryService songViewHistoryService)
            : base(userManager, signInManager, logger)
        {
            this.songViewHistoryService = songViewHistoryService;
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.UserRoleName)]
        public ActionResult<IEnumerable<SongViewModel>> Get()
            => this.Ok(this.songViewHistoryService
                .All<SongViewModel>(this.userManager.GetUserId(this.User)));

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = GlobalConstants.UserRoleName)]
        public ActionResult<IEnumerable<SongViewModel>> Search(SongViewHistorySearchModels filter)
            => this.Ok(this.songViewHistoryService
                .Search<SongViewModel>(filter, this.userManager.GetUserId(this.User)));

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.songViewHistoryService.Delete(id);
            return this.Ok();
        }
    }
}
