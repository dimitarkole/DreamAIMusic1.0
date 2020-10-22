using DreamAIMusic.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamAIMusic.Data.Configurations
{
    public class PlaylistConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> appPlaylist)
        {
            /*appPlaylist
                .HasMany(e => e.PlaylistSongs)
                .WithOne()
                .HasForeignKey(e => e.PlaylistId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);*/
        }
    }
}
