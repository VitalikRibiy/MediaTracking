using MediaTracking.DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasIndex(x => x.Id).IsUnique();

            builder.HasOne(d => d.Director)
                .WithMany(m => m.Medias)
                .HasForeignKey(x => x.DirectorId);

            builder.HasOne(s => s.Studio)
                .WithMany(m => m.Medias)
                .HasForeignKey(x => x.StudioId);

            builder.HasMany(x => x.Reviews)
                .WithOne(x => x.Media);

            builder.HasOne(u => u.ParentMedia)
                        .WithMany(u => u.ChildMedias)
                        .HasForeignKey(u => u.ParentMediaId);
        }
    }
}
