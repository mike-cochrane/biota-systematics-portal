using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystematicsPortal.Models.Entities.Database;

namespace SystematicsPortal.Data.Configuration
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {

        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Document", "documents");

            builder.Property(e => e.DocumentId).ValueGeneratedNever();

            builder.Property(e => e.SerializedDocument)
                .IsRequired()
                .HasColumnType("xml");

            builder.Property(e => e.ValidFrom).HasColumnType("datetime2(2)");

            builder.Property(e => e.ValidTo).HasColumnType("datetime2(2)");
        }
    }
}
