namespace DreamAIMusic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Common.Models;

    public class Song : IAuditInfo, IDeletableEntity, ILikeInfo
    {
        public Song()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Commentars = new HashSet<Commentar>();
            this.CountDisLikes = 0;
            this.CountLikes = 0;
            this.CountViews = 0;
        }

        // Summary:
        //     Gets or sets the primary key for this role.
        public virtual string Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string MusicCategoryId { get; set; }

        public virtual Category MusicCategory { get; set; }

        public string Text { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public long CountViews { get; set; }

        public virtual ICollection<Commentar> Commentars { get; set; }

        public long CountLikes { get; set; }

        public long CountDisLikes { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}