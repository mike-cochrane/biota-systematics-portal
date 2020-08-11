using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystematicsData.Models.Entities.Database;

namespace SystematicsData.Data.Configuration
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
