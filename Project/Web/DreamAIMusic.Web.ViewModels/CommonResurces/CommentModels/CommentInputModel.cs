namespace DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class CommentInputModel : IMapTo<Comment>
    {
        public string Text { get; set; }
    }
}
