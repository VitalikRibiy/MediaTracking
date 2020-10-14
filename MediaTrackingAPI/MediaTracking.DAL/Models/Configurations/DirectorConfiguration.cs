using MediaTracking.DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaTracking.DAL.Models.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {

            builder.HasIndex(e => e.Id).IsUnique();

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.FullName).HasMaxLength(50);
        }
    }
}
