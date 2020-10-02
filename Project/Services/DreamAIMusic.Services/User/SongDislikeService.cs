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

    public class SongDislikeService : ISongDislikeService
    {
        private readonly ApplicationDbContext context;

        public SongDislikeService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Count(string songId)
            => this.context.SongDislikes
            .Where(sd => sd.Id == songId)
            .Count();

        public async Task Create(string songId, string userId)
        {
            var songDislike = new SongDislike();
            songDislike.SongId = songId;
            songDislike.UserId = userId;

            await this.context.SongDislikes.AddAsync(songDislike);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var songDislike = this.context.SongDislikes.Find(id);
            this.context.SongDislikes.Remove(songDislike);
            await this.context.SaveChangesAsync();
        }

        public bool IsDisliked(string songId, string userId)
             => this.context.SongDislikes
                    .Where(sd => sd.Id == songId
                        && sd.UserId == userId)
                    .FirstOrDefault() == null ? false : true;
    }
}
