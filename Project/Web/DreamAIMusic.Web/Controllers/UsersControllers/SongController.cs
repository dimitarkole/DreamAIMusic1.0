namespace DreamAIMusic.Web.Controllers.UsersControllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels.User.SongModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using NHibernate.Mapping;

    public class SongController : UserController
    {
        private readonly ISongService songService;

        public SongController(
            ISongService songService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger)
            : base(userManager, signInManager, logger)
        {
            this.songService = songService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SongViewModel>> GetOwn()
            => this.Ok(this.songService.AllOwn<SongViewModel>(this.userManager.GetUserId(this.User)));

        [HttpPost]
        [DisableRequestSizeLimit]
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

        [Authorize(Roles = GlobalConstants.Roles.UserRoleName)]
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

        [Authorize(Roles = GlobalConstants.Roles.UserRoleName)]
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

        [HttpPost]
        [DisableRequestSizeLimit]
        [Route("[action]")]
        public IActionResult UploadSongFile()
        {
            try
            {
                var imageFile = this.Request.Form.Files[0];
                var mp3File = this.Request.Form.Files[1];
                var userId = this.userManager.GetUserId(this.User);
                if (imageFile.Length > 0)
                {
                    var songName = this.Request.Form["songName"].ToString();
                    songName.Replace(' ', '_');
                    var uniqueName = songName + "_" + this.RandomName();

                    var imageExtension = this.UploadFile(imageFile, uniqueName, "images");
                    var mp3Extension = this.UploadFile(mp3File, uniqueName, "аudio");

                    return this.Ok(new { uniqueSongFilesName = uniqueName,
                        ImageExtension = imageExtension,
                        Mp3Extension = mp3Extension,
                    });
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"Internal server error: {ex}");
            }
        }

        private string RandomName()
        {
            int length = Common.GlobalConstants.CreateFile.RandomNameLength;
            Random random = new Random();
            const string chars = Common.GlobalConstants.CreateFile.RandomNameCharacters;
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string UploadFile(IFormFile file, string uniqueName, string folder)
        {
            var folderName = Path.Combine("client", "src", "assets", "resources", "song", folder);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var songName = this.Request.Form["songName"].ToString();
            string extension = Path.GetExtension(file.FileName);
            uniqueName += extension;
            var fullPath = Path.Combine(pathToSave, uniqueName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return extension;
        }
    }
}
