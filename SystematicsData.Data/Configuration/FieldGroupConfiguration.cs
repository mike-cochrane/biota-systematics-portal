using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystematicsData.Models.Entities.Database;

namespace SystematicsData.Data.Configuration
{
    public class FieldGroupConfiguration : IEntityTypeConfiguration<FieldGroup>
    {

        public void Configure(EntityTypeBuilder<FieldGroup> builder)
        {
            builder.ToTable("FieldGroup", "web");

            builder.Property(e => e.FieldGroupId).ValueGeneratedNever();

            builder.Property(e => e.DisplayFormat).HasMaxLength(250);

            builder.Property(e => e.DisplayTitle).HasMaxLength(200);

            builder.Property(e => e.DocumentClass)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
