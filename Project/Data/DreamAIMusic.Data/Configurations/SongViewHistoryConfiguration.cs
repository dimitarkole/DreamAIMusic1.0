namespace DreamAIMusic.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SongViewHistoryConfiguration : IEntityTypeConfiguration<SongViewHistory>
    {
        public void Configure(EntityTypeBuilder<SongViewHistory> appSongViewHistory)
        {
            appSongViewHistory
                .HasOne(e => e.Song)
                .WithMany(c => c.SongViewHistories)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
