namespace DreamAIMusic.Services.Contracts.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;
    using DreamAIMusic.Web.ViewModels.User.SongReactionModels;

    public interface ICommentReactionService
    {
        Task Create(CommentReactionCreateModel model, string userId);

        Task Delete(string id);

        Task Update(CommentReactionCreateModel model, string id);
    }
}
