namespace DreamAIMusic.Services.Contracts.Common
{
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;
    using System.Threading.Tasks;

    public interface ICommentLikeService
    {
        int Count(string commentId);

        Task Create(CommentLikeInputModel model, string userId);

        Task Delete(string id);
    }
}
