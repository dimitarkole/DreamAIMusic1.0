using DreamAIMusic.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamAIMusic.Data.Configurations
{
    public class SongLikeConfiguration : IEntityTypeConfiguration<SongLike>
    {
        public void Configure(EntityTypeBuilder<SongLike> appSongLike)
        {
            appSongLike
                .HasOne(e => e.Song)
                .WithMany(c => c.SongLikes)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
