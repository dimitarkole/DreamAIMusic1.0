namespace DreamAIMusic.Services.Contracts.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Web.ViewModels.User.PlaylistModels;

    public interface IPlaylistService
    {
        IList<T> All<T>();

        IList<T> Search<T>(string userId, PlaylistSearchModel model);

        IList<T> AllOwn<T>(string userId);

        Task Create(string userId, PlaylistCreateModel model);

        Task Update(string id, PlaylistEditModel model);

        T GetById<T>(string id);

        Task Delete(string id);

        IList<T> AllSongInPlaylist<T>(string id);

        Task AddSongToPlaylist(string id, string songId);

        Task DeletePlaylistSong(string id);
    }
}
