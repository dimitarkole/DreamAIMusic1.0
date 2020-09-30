namespace DreamAIMusic.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamAIMusic.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> appCategoty)
        {
           /* appCategoty
                .HasMany(e => e.Songs)
                .WithOne()
                .HasForeignKey(e => e.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);*/
        }
    }
}
