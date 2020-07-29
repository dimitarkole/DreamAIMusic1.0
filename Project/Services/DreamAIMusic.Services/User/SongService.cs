namespace DreamAIMusic.Services.User
{
    using DreamAIMusic.Data;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels.UserModels.SongModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using DreamAIMusic.Services.Mapping;
    using System.Linq;
    using DreamAIMusic.Services.Contracts.Administration;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CategoryModels;
    using System.Globalization;

    public class SongService : ISongService
    {
        private readonly ApplicationDbContext context;

        public SongService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> All<T>() =>
            this.context.Songs.To<T>();

        public IEnumerable<T> AllOwn<T>(string userId)
            => this.context.Songs
            .Where(s => s.UserId == userId)
            .To<T>();

        public async Task Create(SongInputModel model, string userId)
        {
            Song song = model.To<Song>();
            song.UserId = userId;
            await this.context.Songs.AddAsync(song);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            Song product = this.context.Songs.Find(id);
            this.context.Songs.Remove(product);
            await this.context.SaveChangesAsync();
        }

        public T GetById<T>(string id) => this.context.Songs
            .Where(s => s.Id == id).To<T>().FirstOrDefault();

        public bool IsOwn(string songId, string userId)
            => this.context.Songs
            .Where(s =>
                s.Id == songId
                && s.UserId == userId)
            .FirstOrDefault()
            == null ?
            false : true;

        public async Task Update(string id, SongEditModel model)
        {
            Song song = this.context.Songs.Find(id);
            song.Name = model.Name;
            song.Path = model.Path;
            song.MusicCategoryId = model.CategoryId;
            song.Text = model.Text;

            this.context.Songs.Update(song);
            await this.context.SaveChangesAsync();
        }
    }
}
