namespace DreamAIMusic.Web.ViewModels.User.PlaylistModels
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class PlaylistCreateModel : IMapTo<Playlist>
    {
        public string Name { get; set; }
    }
}
