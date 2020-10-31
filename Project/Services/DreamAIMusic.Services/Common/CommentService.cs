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
    using DreamAIMusic.Services.Mapping;
    using DreamAIMusic.Web.ViewModels.CommonResurces.CommentModels;

    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext context;

        public CommentService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> All<T>(string songId)
            => this.context.Comments
                    .Where(c =>
                        c.SongId == songId
                        && c.ParentComment == null)
                    .OrderByDescending(c => c.CreatedOn)
                    .To<T>();

        public async Task Create(CommentInputModel model, string userId)
        {
            var songId = model.SongId;
            Comment comment = model.To<Comment>();
            Song song = this.context.Songs.Find(songId);
            ApplicationUser user = this.context.Users.Find(userId);

            comment.UserId = userId;
            comment.SongId = songId;
            comment.User = user;
            comment.Song = song;
            await this.context.Comments.AddAsync(comment);
            await this.context.SaveChangesAsync();
        }

        public async Task CreateChildrenComment(CommentEditModel model, string userId)
        {
            string parentCommentId = model.ParentCommentId;
            Comment parentComment = this.context.Comments.Find(parentCommentId);
            string songId = parentComment.SongId;
            Song song = this.context.Songs.Find(songId);
            ApplicationUser user = this.context.Users.Find(userId);

            Comment comment = model.To<Comment>();
            comment.UserId = userId;
            comment.SongId = songId;
            comment.User = user;
            comment.Song = song;
            comment.ParentComment = parentComment;
            comment.ParentCommentId = parentCommentId;
            parentComment.CommentsChildren.Add(comment);
            this.context.Comments.Update(parentComment);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            Comment comment = this.context.Comments.Find(id);
            this.context.Comments.Remove(comment);
            await this.context.SaveChangesAsync();
        }

        public async Task Update(string id, CommentEditModel model)
        {
            Comment comment = this.context.Comments.Find(id);
            comment.Text = model.Text;

            this.context.Comments.Update(comment);
            await this.context.SaveChangesAsync();
        }
    }
}
