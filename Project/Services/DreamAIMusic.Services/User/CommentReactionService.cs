namespace DreamAIMusic.Services.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Data;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.User;
    using DreamAIMusic.Services.Mapping;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;

    public class CommentReactionService : ICommentReactionService
    {
        private readonly ApplicationDbContext context;

        public CommentReactionService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Create(CommentReactionCreateModel model, string userId)
        {
            var commentReaction = model.To<CommentReaction>();
            commentReaction.UserId = userId;
            commentReaction.CommentId = model.CommentId;
            await this.context.CommentReactions.AddAsync(commentReaction);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var commentReaction = this.context.CommentReactions.Find(id);
            this.context.CommentReactions.Remove(commentReaction);
            await this.context.SaveChangesAsync();
        }

        public async Task Update(CommentReactionCreateModel model, string id)
        {
            var commentReaction = this.context.CommentReactions.Find(id);
            commentReaction.Reaction = model.Reaction;

            this.context.CommentReactions.Update(commentReaction);
            await this.context.SaveChangesAsync();
        }
    }
}
