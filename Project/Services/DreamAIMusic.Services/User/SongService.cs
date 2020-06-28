namespace DreamAIMusic.Services.User
{
    using DreamAIMusic.Data;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Web.ViewModels.UserModels.MusicModels;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using DreamAIMusic.Services.Mapping;
    using System.Linq;

    public class SongService : ISongService
    {
        private readonly ApplicationDbContext context;

        public SongService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<T> All<T>() => this.context.Songs.To<T>().ToList();

        public async Task<string> Create(SongInputModel model, string userId)
        {
            Song song = model.To<Song>();
            song.UserId = userId;
            await this.context.Songs.AddAsync(song);
            await this.context.SaveChangesAsync();

            return song.Id;
        }

        public async Task Delete(string id)
        {
            Song song = this.context.Songs.Find(id);
            this.context.Songs.Remove(song);
            await this.context.SaveChangesAsync();
        }

        public T GetById<T>(string id) =>
            this.context.Songs
            .Where(m => m.Id == id)
            .To<T>()
            .FirstOrDefault();

        public async Task Update(string id, SongEditModel model)
        {
            Song song = this.context.Songs
               .FirstOrDefault(s => s.Id == id);

            model.To<Song>(song);

            this.context.Songs.Update(song);
            await this.context.SaveChangesAsync();
        }
    }
}
