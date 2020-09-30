namespace DreamAIMusic.Web.Controllers.UsersControllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels.User.PlaylistModels;
    using DreamAIMusic.Web.ViewModels.User.SongModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class PlaylistController : ApiController
    {
        private readonly IPlaylistService playlistService;

        public PlaylistController(
            IPlaylistService playlistService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
            this.playlistService = playlistService;
        }

        [HttpGet(nameof(GetOwn))]
        public ActionResult<IEnumerable<PlaylistViewModel>> GetOwn()
           => this.Ok(this.playlistService.AllOwn<PlaylistViewModel>(this.userManager.GetUserId(this.User)));

        [HttpGet]
        public ActionResult<IEnumerable<PlaylistViewModel>> Get()
         => this.Ok(this.playlistService.All<PlaylistViewModel>());

        [HttpGet("{id}")]
        public ActionResult<PlaylistViewModel> Get(string id) =>
           this.Ok(this.playlistService.GetById<PlaylistViewModel>(id));

        [HttpPost]
        public async Task<IActionResult> Post(PlaylistCreateModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.playlistService.Create(model, userId);
            return this.StatusCode(StatusCodes.Status201Created);
        }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, PlaylistEditModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            if (!this.playlistService.IsOwn(id, userId))
            {
                return this.StatusCode(StatusCodes.Status406NotAcceptable);
            }

            await this.playlistService.Update(model, id);
            return this.Ok();
        }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            if (this.playlistService.IsOwn(id, userId))
            {
                return this.StatusCode(StatusCodes.Status406NotAcceptable);
            }

            await this.playlistService.Delete(id);
            return this.Ok();
        }

        [HttpGet(nameof(Search))]
        public ActionResult<IEnumerable<PlaylistViewModel>> Search(PlaylistSearchModel model)
         => this.Ok(this.playlistService.Search<PlaylistViewModel>(model));

        [HttpGet(nameof(SearchOwn))]
        public ActionResult<IEnumerable<PlaylistViewModel>> SearchOwn(PlaylistSearchModel model)
         => this.Ok(this.playlistService.SearchOwn<PlaylistViewModel>(model, this.userManager.GetUserId(this.User)));

        [HttpPost(nameof(PostAddSongToPlaylist) + "/{id}")]
        public async Task<IActionResult> PostAddSongToPlaylist(string id, string songId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.playlistService.AddSongToPlaylist(id, songId);
            return this.StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet(nameof(GetAllSongAtPlaylist) + "/{id}")]
        public ActionResult<IEnumerable<PlaylistViewModel>> GetAllSongAtPlaylist(string id)
         => this.Ok(this.playlistService.AllSongInPlaylist<SongPlayModel>(id));

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [HttpDelete(nameof(DeletePlaylistSong) + "/{id}")]
        public async Task<IActionResult> DeletePlaylistSong(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            if (this.playlistService.IsOwn(id, userId))
            {
                return this.StatusCode(StatusCodes.Status406NotAcceptable);
            }

            await this.playlistService.DeletePlaylistSong(id);
            return this.Ok();
        }
    }
}
