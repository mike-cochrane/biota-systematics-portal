using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Database;

namespace SystematicsPortal.Data.Configuration
{
    public class ContentConfigurationConfiguration : IEntityTypeConfiguration<ContentConfiguration>
    {

        public void Configure(EntityTypeBuilder<ContentConfiguration> builder)
        {
            builder.ToTable("ContentConfiguration", "web");

            builder.Property(e => e.ContentConfigurationId).ValueGeneratedNever();

            builder.Property(e => e.Page).HasMaxLength(100);

            builder.Property(e => e.Section).HasMaxLength(100);

            builder.Property(e => e.SectionTitle).HasMaxLength(200);
        }
    }
}
