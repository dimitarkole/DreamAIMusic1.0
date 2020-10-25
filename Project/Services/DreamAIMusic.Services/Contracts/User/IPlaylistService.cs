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

        IList<T> SearchOwn<T>(PlaylistSearchModel model, string userId);

        IList<T> Search<T>(PlaylistSearchModel model);

        IList<T> AllOwn<T>(string userId);

        IList<T> GetOwnForAddingSong<T>(string songId, string userId);

        Task Create(PlaylistCreateModel model, string userId);

        Task Update(PlaylistEditModel model, string id);

        T GetById<T>(string id);

        Task Delete(string id);

        IList<T> AllSongInPlaylist<T>(string id);

        Task AddSongToPlaylist(SongToPlaylistCreateModel model);

        Task DeletePlaylistSong(string id);

        bool IsOwn(string id, string userId);
    }
}
