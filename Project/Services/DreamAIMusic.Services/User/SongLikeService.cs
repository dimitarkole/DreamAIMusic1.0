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

    public class SongLikeService : ISongLikeService
    {
        private readonly ApplicationDbContext context;

        public SongLikeService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Count(string songId)
            => this.context.SongLikes
            .Where(sd => sd.Id == songId)
            .Count();

        public async Task Create(string songId, string userId)
        {
            var songLike = new SongLike();
            songLike.SongId = songId;
            songLike.UserId = userId;

            await this.context.SongLikes.AddAsync(songLike);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var songLike = this.context.SongLikes.Find(id);
            this.context.SongLikes.Remove(songLike);
            await this.context.SaveChangesAsync();
        }

        public bool IsLiked(string songId, string userId)
             => this.context.SongLikes
                    .Where(sd => sd.Id == songId
                        && sd.UserId == userId)
                    .FirstOrDefault() == null ? false : true;
    }
}
