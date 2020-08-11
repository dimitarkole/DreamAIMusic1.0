namespace DreamAIMusic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Common.Models;

    public class Comment : IAuditInfo, IDeletableEntity
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.CommentsChildren = new HashSet<Comment>();
            this.CommentLikes = new HashSet<CommentLike>();
            this.CommentDislikes = new HashSet<CommentDislike>();
        }

        // Summary:
        //     Gets or sets the primary key for this role.
        public virtual string Id { get; set; }

        public virtual string SongId { get; set; }

        public virtual Song Song { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string ParentCommentId { get; set; }

        public virtual Comment ParentComment { get; set; }

        public virtual ICollection<Comment> CommentsChildren { get; set; }

        public virtual ICollection<CommentDislike> CommentDislikes { get; set; }

        public virtual ICollection<CommentLike> CommentLikes { get; set; }
    }
}
