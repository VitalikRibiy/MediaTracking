using MediaTracking.DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {

            builder.HasIndex(e => e.Id).IsUnique();

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.FullName).HasMaxLength(50);

        }
    }
}
