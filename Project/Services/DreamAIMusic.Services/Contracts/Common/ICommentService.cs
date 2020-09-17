namespace DreamAIMusic.Services.Contracts.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;

    public interface ICommentService
    {
        IEnumerable<T> All<T>(string songId);

        Task Create(CommentInputModel model, string userId);

        Task CreateChildrenComment(CommentEditModel model, string userId);

        Task Update(string id, CommentEditModel model);

        Task Delete(string id);
    }
}
