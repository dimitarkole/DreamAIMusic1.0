namespace DreamAIMusic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Common.Models;

    public class Playlist : IAuditInfo, IDeletableEntity
    {
        public Playlist()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PlaylistSongs = new List<PlaylistSong>();
        }

        //
        // Summary:
        //     Gets or sets the primary key for this role.
        public virtual string Id { get; set; }

        public string Name { get; set; }

        public virtual Category Category { get; set; }

        public virtual string CategoryId { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
