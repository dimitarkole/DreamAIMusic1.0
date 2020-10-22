namespace DreamAIMusic.Web.ViewModels.User.SongReactionModels
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class SongReactionSearchModel : IMapTo<SongReaction>, IMapFrom<SongReaction>
    {
        public string SongId { get; set; }
    }
}
