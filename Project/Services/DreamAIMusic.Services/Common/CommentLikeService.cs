namespace DreamAIMusic.Services.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using DreamAIMusic.Data;
    using DreamAIMusic.Data.Models;
    using DreamAIMusic.Services.Contracts.Common;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;

    public class CommentLikeService : ICommentLikeService
    {
        private readonly ApplicationDbContext context;

        public CommentLikeService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Count(string commentId)
            => this.context.CommentLikes
               .Where(c => c.CommentId == commentId)
               .Count();

        public async Task Create(string commentId, string userId)
        {
            _ = this.DeleteOwnCommentDislike(commentId, userId);

            var user = this.context.Users
               .Where(u => u.Id == userId)
               .FirstOrDefault();
            var comment = this.context.Comments
                .Where(c => c.Id == commentId)
                .FirstOrDefault();

            CommentLike commentLike = new CommentLike
            {
                User = user,
                UserId = userId,
                CommentId = commentId,
                Comment = comment,
            };

            await this.context.CommentLikes.AddAsync(commentLike);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            CommentLike commentLikes = this.context.CommentLikes.Find(id);
            this.context.CommentLikes.Remove(commentLikes);
            await this.context.SaveChangesAsync();
        }

        private async Task DeleteOwnCommentDislike(string commentId, string userId)
        {
            CommentDislike commentDislike = this.context.CommentDislikes
                .Where(c => c.CommentId == commentId
                    && c.UserId == userId)
                .FirstOrDefault();
            if (commentDislike != null)
            {
                this.context.CommentDislikes.Remove(commentDislike);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
