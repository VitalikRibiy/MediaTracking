using MediaTracking.DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Configurations
{
    public class MediaCategoryConfiguration : IEntityTypeConfiguration<MediaCategory>
    {
        public void Configure(EntityTypeBuilder<MediaCategory> builder)
        {
            builder.HasKey(mc => new { mc.MediaId, mc.CategoryId });
            builder.HasOne(mc => mc.Media)
                .WithMany(m => m.MediaCategories)
                .HasForeignKey(mc => mc.MediaId);
            builder.HasOne(mc => mc.Category)
                .WithMany(c => c.MediaCategories)
                .HasForeignKey(mc => mc.CategoryId);
        }
    }
}
