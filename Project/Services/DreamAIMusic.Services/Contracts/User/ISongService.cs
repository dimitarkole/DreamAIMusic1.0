namespace DreamAIMusic.Services.Contracts.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Web.ViewModels.UserModels.MusicModels;

    public interface ISongService
    {
        IList<T> All<T>();

        IList<T> AllOwenMusic<T>(string userId);

        Task<string> Create(SongInputModel model, string userId);

        Task Update(string id, SongEditModel model);

        T GetById<T>(string id);

        Task Delete(string id);
    }
}
