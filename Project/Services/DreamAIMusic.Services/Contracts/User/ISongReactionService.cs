namespace DreamAIMusic.Services.Contracts.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Web.ViewModels.User.SongReactionModels;

    public interface ISongReactionService
    {
        Task Create(SongReactionCreateModel model, string userId);

        Task Delete(string id);

        Task Update(SongReactionCreateModel model, string id);

        SongReactionViewModel GetOwnReaction(string songId, string userId);
    }
}
