namespace DreamAIMusic.Web.Controllers
{
    using System.Diagnostics;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels;
    using DreamAIMusic.Web.ViewModels.UserModels.MusicModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ApiController
    {
        private readonly ISongService songService;

        public HomeController(ISongService songService)
        {
            this.songService = songService;
        }

        [Route(nameof(Index))]
        [HttpGet]
        public IActionResult Index()
        {
            // var musics = this.songService.All<SongViewModel>();
            return this.Ok("Works Index");
        }

        [Route(nameof(Privacy))]
        [HttpGet]
        public IActionResult Privacy()
        {
            return this.Ok("Works Privacy");

        }

        [Route(nameof(Error))]
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.Ok("Works Error");

            /*
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });*/
        }
    }
}
