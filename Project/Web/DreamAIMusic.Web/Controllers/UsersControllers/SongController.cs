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
    using DreamAIMusic.Web.ViewModels.UserModels.SongModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class SongController : UserController
    {
        private readonly ISongService songService;
        private readonly IWebHostEnvironment webHostEnviroment;

        public SongController(
            ISongService songService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger,
            IWebHostEnvironment webHostEnviroment,
            IHostingEnvironment hostingEnvironment)
            : base(userManager, signInManager, logger, hostingEnvironment)
        {
            this.songService = songService;
            this.webHostEnviroment = webHostEnviroment;
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

            // uploadImage
           /* try
            {
                var file = model.ImageFile;
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                else
                {
                    return this.BadRequest();
                }*/

                await this.songService.Create(model, userId);
                return this.StatusCode(StatusCodes.Status201Created);
           /* }
            catch (Exception ex)
            {
                return this.StatusCode(500, $"Internal server error: {ex}");
            }*/

        }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
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

        [Authorize(Roles = GlobalConstants.UserRoleName)]
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
        public IActionResult UploadImage()
        {
            try
            {
                var file = this.Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return this.Ok(new { dbPath });
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
    }
}
