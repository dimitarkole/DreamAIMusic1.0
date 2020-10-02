namespace DreamAIMusic.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SongDislikeConfiguration : IEntityTypeConfiguration<SongDislike>
    {
        public void Configure(EntityTypeBuilder<SongDislike> appSongDislike)
        {
            appSongDislike
                .HasOne(e => e.Song)
                .WithMany(c => c.SongDislikes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
