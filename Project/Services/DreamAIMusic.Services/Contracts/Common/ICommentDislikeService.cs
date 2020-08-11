namespace DreamAIMusic.Services.Contracts.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentDislikeService
    {
        int Count(string commentarId);

        Task Create(string commentarId, string userId);

        Task Delete(string id);
    }
}
