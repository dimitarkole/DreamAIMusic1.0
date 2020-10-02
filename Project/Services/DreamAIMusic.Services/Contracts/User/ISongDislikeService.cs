namespace DreamAIMusic.Services.Contracts.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISongDislikeService
    {
        int Count(string songId);

        Task Create(string songId, string userId);

        Task Delete(string id);

        bool IsDisliked(string songId, string userId);
    }
}
