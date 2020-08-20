using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystematicsData.Data.Models;

namespace SystematicsData.Data.Configuration
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {

        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("Document", "documents");

            builder.HasKey(key => key.DocumentId);
            builder.Property(prop => prop.DocumentId).ValueGeneratedNever();

            builder.Property(prop => prop.SerializedDocument)
                .IsRequired()
                .HasColumnType("xml");

            builder.Property(prop => prop.ValidFrom).HasColumnType("datetime2(2)");

            builder.Property(prop => prop.ValidTo).HasColumnType("datetime2(2)");
        }
    }
}
