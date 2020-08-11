namespace DreamAIMusic.Services.Contracts.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentLikeService
    {
        int Count(string commentId);

        Task Create(string commentId, string userId);

        Task Delete(string id);
    }
}
