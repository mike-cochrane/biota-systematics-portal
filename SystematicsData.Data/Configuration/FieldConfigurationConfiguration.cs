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

            builder.Property(e => e.FieldConfigurationId).ValueGeneratedNever();

            builder.Property(e => e.DataDocumentXpath)
                .HasColumnName("DataDocumentXPath")
                .HasMaxLength(500);

            builder.Property(e => e.DisplayAsIcon).HasMaxLength(150);

            builder.Property(e => e.DisplayFormat).HasMaxLength(150);

            builder.Property(e => e.DocumentClass).HasMaxLength(200);

            builder.Property(e => e.Labels).HasColumnType("xml");

            builder.HasOne(d => d.FieldGroup)
                .WithMany(p => p.FieldConfiguration)
                .HasForeignKey(d => d.FieldGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("frkFieldConfigurationFieldGroup");
        }
    }
}
