namespace DreamAIMusic.Services.Contracts.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Web.ViewModels.User.SongViewHistoryModels;

    public interface ISongViewHistoryService
    {
        IEnumerable<T> All<T>(string userId);

        IEnumerable<T> Search<T>(SongViewHistorySearchModels filter, string userId);

        Task Create(string songId, string userId);

        Task Delete(string id);
    }
}
