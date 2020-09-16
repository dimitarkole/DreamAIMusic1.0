namespace DreamAIMusic.Services.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Data;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Services.Mapping;
    using DreamAIMusic.Web.ViewModels.User.PlaylistModels;

    public class PlaylistService : IPlaylistService
    {
        private readonly ApplicationDbContext context;

        public PlaylistService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddSongToPlaylist(string id, string songId)
        {
            var newPlaylistSong = new PlaylistSong();
            newPlaylistSong.PlaylistId = id;
            newPlaylistSong.SongId = songId;
            await this.context.PlaylistSongs.AddAsync(newPlaylistSong);
            await this.context.SaveChangesAsync();
        }

        public IList<T> All<T>() => this.context.Playlists
               .Where(p => p.DeletedOn == null)
               .To<T>()
               .ToList();

        public IList<T> AllOwn<T>(string userId) => this.context.Playlists
               .Where(p => p.DeletedOn == null && p.UserId == userId)
               .To<T>()
               .ToList();

        public IList<T> AllSongInPlaylist<T>(string id) => this.context.PlaylistSongs
               .Where(p => p.DeletedOn == null && p.PlaylistId == id)
               .To<T>()
               .ToList();

        public async Task Create(string userId, PlaylistCreateModel model)
        {
            Playlist playlist = model.To<Playlist>();
            playlist.UserId = userId;
            await this.context.Playlists.AddAsync(playlist);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            Playlist playlist = this.context.Playlists.Find(id);
            this.context.Playlists.Remove(playlist);
            await this.context.SaveChangesAsync();
        }

        public async Task DeletePlaylistSong(string id)
        {
            var removePlaylistSong = this.context.PlaylistSongs.Find(id);
            this.context.PlaylistSongs.Remove(removePlaylistSong);
            await this.context.SaveChangesAsync();
        }

        public T GetById<T>(string id) => this.context.Playlists
               .Where(p => p.DeletedOn == null && p.Id == id)
               .To<T>()
               .FirstOrDefault();

        public IList<T> Search<T>(string userId, PlaylistSearchModel model)
        {
            throw new NotImplementedException();
        }

        public async Task Update(string id, PlaylistEditModel model)
        {
            Playlist playlist = this.context.Playlists
                 .FirstOrDefault(s => s.Id == id);

            model.To<Playlist>(playlist);

            this.context.Playlists.Update(playlist);
            await this.context.SaveChangesAsync();
        }
    }
}
