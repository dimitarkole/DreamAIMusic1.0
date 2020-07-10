namespace DreamAIMusic.Web.Areas.User.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.Areas.Identity.Pages.Account;
    using DreamAIMusic.Web.Controllers;
    using DreamAIMusic.Web.ViewModels.UserModels.MusicModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using static DreamAIMusic.Common.GlobalConstants;

    [Authorize(Roles = GlobalConstants.UserRoleName)]
    [Area("User")]
    public class SongController : UserController
    {
        private readonly ISongService musicService;

        public SongController(
            ISongService musicService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LogoutModel> logger,
            IHostingEnvironment hostingEnvironment)
            : base(userManager, signInManager, logger, hostingEnvironment)
        {
            this.musicService = musicService;
        }

        // GET: Song/Create
        [HttpGet]
        [Route("/Song/Create")]
        public IActionResult Create()
        {
            var model = this.musicService.CreateSongModel();
            return this.View(model);
        }

        // POST: Song/Create
        [HttpPost]
        [Route("/Song/Create")]
        public async Task<IActionResult> Create(SongInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            var folder = Folder.SongFolderPath;
            string extension = Path.GetExtension(input.File.FileName);
            var fileName = input.Name + extension;
            var filePath = Path.Combine(
                    this.hostingEnvironment.WebRootPath + folder,
                    Path.GetFileName(fileName));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await input.File.CopyToAsync(stream);
            }

            input.Path = fileName;

            this.ViewData["message"] = await this.musicService.Create(input, userId) + " catId: " + input.MusicCategoryId;
            var returnModel = this.musicService.CreateSongModel();

            return this.View(returnModel);
        }

        // GET: TransactionModels
        public IActionResult Index()
        {
            var userId = this.userManager.GetUserId(this.User);
            var model = this.musicService.AllOwenMusic<OwnSongViewModel>(userId);
            return this.View(model);
        }

        // GET: TransactionModels
        public IActionResult Details(string id)
        {
            var model = this.musicService.GetById<SongViewModel>(id);
            return this.View(model);
        }

        public IActionResult UploadFile()
        {
            return this.View();
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var folder = "Avatars";

            var filePath = Path.Combine(
                    this.hostingEnvironment.WebRootPath + "\\images\\" + folder,
                    Path.GetFileName(this.userId + "_" + file.FileName)); // Full path to file in temp location

            // foreach (var formFile in files.Where(f => f.Length > 0))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                //} // Copy files to FileSystem using Streams

                return Ok(new { count = 0, file.Length, filePath });
            }
        }
    }
}