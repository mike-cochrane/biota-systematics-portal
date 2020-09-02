using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystematicsData.Data.Models;

namespace SystematicsData.Data.Configuration
{
    public class FieldGroupConfiguration : IEntityTypeConfiguration<FieldGroup>
    {

        public void Configure(EntityTypeBuilder<FieldGroup> builder)
        {
            builder.ToTable("FieldGroup", "web");

            builder.HasKey(key => key.FieldGroupId);
            builder.Property(e => e.FieldGroupId).ValueGeneratedNever();

            builder.Property(e => e.Labels).HasColumnType("xml");

            builder.Property(e => e.DocumentClass)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
