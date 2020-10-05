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
    using DreamAIMusic.Web.ViewModels.User.SongViewHistoryModels;

    public class SongViewHistoryService : ISongViewHistoryService
    {
        private readonly ApplicationDbContext context;

        public SongViewHistoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> All<T>(string userId)
             => this.context.SongViewHistories
                .Where(s => s.UserId == userId)
                .To<T>();

        public IEnumerable<T> Search<T>(SongViewHistorySearchModels filter, string userId)
        {
            IQueryable<SongViewHistory> songViewHistories = this.context.SongViewHistories
                 .Where(s => s.UserId == userId);
            if (!string.IsNullOrEmpty(filter.Name))
            {
                songViewHistories = songViewHistories
                    .Where(s => s.UserId == userId
                        && s.Song.Name.Contains(filter.Name));
            }

            return songViewHistories.To<T>();
        }

        public async Task Create(string songId, string userId)
        {
            SongViewHistory songViewHistory = new SongViewHistory();
            songViewHistory.UserId = userId;
            songViewHistory.SongId = songId;
            await this.context.SongViewHistories.AddAsync(songViewHistory);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            SongViewHistory songViewHistory = this.context.SongViewHistories.Find(id);
            this.context.SongViewHistories.Remove(songViewHistory);
            await this.context.SaveChangesAsync();
        }
    }
}
