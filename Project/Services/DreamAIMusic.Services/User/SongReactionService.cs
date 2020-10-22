namespace DreamAIMusic.Services.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DreamAIMusic.Common;
    using DreamAIMusic.Data;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Services.Mapping;
    using DreamAIMusic.Web.ViewModels.User.SongReactionModels;

    public class SongReactionService : ISongReactionService
    {
        private readonly ApplicationDbContext context;

        public SongReactionService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Create(SongReactionCreateModel model, string userId)
        {
            var songReaction = model.To<SongReaction>();
            songReaction.UserId = userId;
            songReaction.SongId = model.SongId;
            await this.context.SongReactions.AddAsync(songReaction);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var songReaction = this.context.SongReactions.Find(id);
            this.context.SongReactions.Remove(songReaction);
            await this.context.SaveChangesAsync();
        }

        public SongReactionViewModel GetOwnReaction(string songId, string userId)
        {
            var result = this.context.SongReactions
                .Where(r => r.UserId == userId
                    && r.SongId == songId)
                .To<SongReactionViewModel>()
                .FirstOrDefault();

            if (result == null)
            {
                return new SongReactionViewModel()
                {
                    Reaction = Reaction.None,
                };
            }

            return result;
        }

        public async Task Update(SongReactionCreateModel model, string id)
        {
            var songReaction = this.context.SongReactions.Find(id);
            songReaction.Reaction = model.Reaction;

            this.context.SongReactions.Update(songReaction);
            await this.context.SaveChangesAsync();
        }
    }
}
