namespace DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels
{
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Mapping;

    public class CommentEditModel : IMapTo<Comment>
    {
        public string Text { get; set; }

        public string ParentCommentId { get; set; }
    }
}
