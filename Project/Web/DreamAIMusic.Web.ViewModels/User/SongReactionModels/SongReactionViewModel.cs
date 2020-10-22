namespace DreamAIMusic.Web.ViewModels.User.SongReactionModels
{
    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class SongReactionViewModel : IMapFrom<SongReaction>, IMapTo<SongReaction>
    {
        public Reaction Reaction { get; set; }
        
        public string Id { get; set; }
    }
}
