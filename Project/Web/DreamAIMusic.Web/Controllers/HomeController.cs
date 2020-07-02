namespace DreamAIMusic.Web.Controllers
{
    using System.Diagnostics;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels;
    using DreamAIMusic.Web.ViewModels.UserModels.MusicModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ISongService songService;

        public HomeController(ISongService songService)
        {
            this.songService = songService;
        }

        public IActionResult Index()
        {
            var musics = this.songService.All<SongViewModel>();
            return this.View(musics);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
