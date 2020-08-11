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

    public class CommentDislikeService : ICommentDislikeService
    {
        private readonly ApplicationDbContext context;

        public CommentDislikeService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Count(string commentId)
          => this.context.CommentDislikes
             .Where(c => c.CommentId == commentId)
             .Count();

        public async Task Create(string commentId, string userId)
        {
            _ = this.DeleteOwnCommentLike(commentId, userId);
            var user = this.context.Users
                .Where(u => u.Id == userId)
                .FirstOrDefault();
            var comment = this.context.Comments
                .Where(c => c.Id == commentId)
                .FirstOrDefault();
            var commentDislike = new CommentDislike
            {
                User = user,
                UserId = userId,
                CommentId = commentId,
                Comment = comment,
            };

            await this.context.CommentDislikes.AddAsync(commentDislike);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var commentDislike = this.context.CommentDislikes.Find(id);
            this.context.CommentDislikes.Remove(commentDislike);
            await this.context.SaveChangesAsync();
        }

        private async Task DeleteOwnCommentLike(string commentId, string userId)
        {
            CommentLike commentLike = this.context.CommentLikes
                .Where(c => c.CommentId == commentId
                    && c.UserId == userId)
                .FirstOrDefault();
            if (commentLike != null)
            {
                this.context.CommentLikes.Remove(commentLike);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
