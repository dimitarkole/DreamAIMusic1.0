namespace DreamAIMusic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Common.Models;

    public class CommentDislike : IAuditInfo, IDeletableEntity
    {
        public CommentDislike()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        //
        // Summary:
        //     Gets or sets the primary key for this role.
        public virtual string Id { get; set; }

        public virtual string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual string CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
