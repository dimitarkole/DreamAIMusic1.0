namespace DreamAIMusic.Services.Contracts.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Web.ViewModels.User.SongModels;

    public interface ISongService
    {
        IEnumerable<T> All<T>();

        IEnumerable<T> AllOwn<T>(string userId);

        Task Create(SongInputModel model, string userId);

        T GetById<T>(string id);

        Task Update(string id, SongEditModel model);

        Task Delete(string id);

        bool IsOwn(string songId, string userId);
    }
}
