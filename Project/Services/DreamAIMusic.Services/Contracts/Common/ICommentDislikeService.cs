namespace DreamAIMusic.Services.Contracts.Common
{
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentDislikeService
    {
        int Count(string commentarId);

        Task Create(CommentDislikeInputModel model, string userId);

        Task Delete(string id);
    }
}
