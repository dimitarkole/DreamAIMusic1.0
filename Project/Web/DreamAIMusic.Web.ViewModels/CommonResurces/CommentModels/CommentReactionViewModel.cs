namespace DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels
{
    using DreamAIMusic.Common;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class CommentReactionViewModel : IMapFrom<CommentReaction>
    {
        public Reaction Reaction { get; set; }

        public string Id { get; set; }
    }
}
