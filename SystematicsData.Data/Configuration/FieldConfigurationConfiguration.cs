using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystematicsData.Data.Models;

namespace SystematicsData.Data.Configuration
{
    public class FieldConfigurationConfiguration : IEntityTypeConfiguration<FieldConfiguration>
    {
        public void Configure(EntityTypeBuilder<FieldConfiguration> builder)
        {
            builder.ToTable("FieldConfiguration", "web");

            builder.HasKey(key => key.FieldConfigurationId);
            builder.Property(e => e.FieldConfigurationId).ValueGeneratedNever();

            builder.Property(e => e.Labels).HasColumnType("xml");

            builder.HasOne(d => d.FieldGroup)
                .WithMany(p => p.FieldConfiguration)
                .HasForeignKey(d => d.FieldGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("frkFieldConfigurationFieldGroup");
        }
    }
}
