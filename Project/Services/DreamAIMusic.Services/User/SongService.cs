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
    using DreamAIMusic.Services.Contracts.Administration;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CategoryModels;

    public class SongService : ISongService
    {
        private readonly ApplicationDbContext context;
        private readonly ICategoryService categoryService;
        

        public SongService(ApplicationDbContext context, ICategoryService categoryService)
        {
            this.context = context;
            this.categoryService = categoryService;
        }

        public IList<T> All<T>() => this.context.Songs
             .Where(s => s.DeletedOn == null)
            .To<T>().ToList();

        public IList<T> AllOwenMusic<T>(string userId) => this.context.Songs
            .Where(s => s.UserId == userId
                && s.DeletedOn == null)
            .To<T>().ToList();

        public async Task<string> Create(SongInputModel model, string userId)
        {
            Song song = model.To<Song>();
            song.UserId = userId;
            await this.context.Songs.AddAsync(song);
            await this.context.SaveChangesAsync();

            return song.Id;
        }

        public SongInputModel CreateSongModel()
        {
            var model = new SongInputModel() {
                Categories = this.categoryService.All<CategoryViewModel>().ToList(),
            };
            return model;
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
