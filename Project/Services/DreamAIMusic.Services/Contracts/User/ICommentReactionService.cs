namespace DreamAIMusic.Services.Contracts.User
{
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;
    using System.Threading.Tasks;

    public interface ICommentReactionService
    {
        Task Create(CommentReactionCreateModel model, string userId);

        Task Delete(string id);

        Task Update(CommentReactionCreateModel model, string id);

        CommentReactionViewModel GetOwnReaction(string songId, string userId);
    }
}
