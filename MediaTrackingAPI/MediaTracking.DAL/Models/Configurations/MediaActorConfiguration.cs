using MediaTracking.DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Configurations
{
    public class MediaActorConfiguration : IEntityTypeConfiguration<MediaActor>
    {
        public void Configure(EntityTypeBuilder<MediaActor> builder)
        {
            builder.HasKey(ma => new { ma.MediaId, ma.ActorId });
            builder.HasOne(ma => ma.Media)
                .WithMany(m => m.MediaActors)
                .HasForeignKey(ma => ma.MediaId);
            builder.HasOne(ma => ma.Actor)
                .WithMany(a => a.MediaActors)
                .HasForeignKey(ma => ma.ActorId);
        }
    }
}
