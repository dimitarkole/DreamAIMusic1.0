namespace DreamAIMusic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Common.Models;

    public class SongDislike : IAuditInfo, IDeletableEntity
    {
        public SongDislike()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.Id = Guid.NewGuid().ToString();
        }

        //
        // Summary:
        //     Gets or sets the primary key for this role.
        public virtual string Id { get; set; }

        public virtual string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual string SongId { get; set; }

        public virtual Song Song { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
