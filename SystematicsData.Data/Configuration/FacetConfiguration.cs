using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystematicsData.Models.Entities.Database;

namespace SystematicsData.Data.Configuration
{
    public class FacetConfiguration : IEntityTypeConfiguration<Facet>
    {

        public void Configure(EntityTypeBuilder<Facet> builder)
        {
            builder.ToTable("Facet", "web");

            builder.Property(e => e.FacetId).ValueGeneratedNever();

            builder.Property(e => e.Facet1)
                .IsRequired()
                .HasColumnName("Facet")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.FacetGroup)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.FacetType)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Labels).HasColumnType("xml");

            builder.Property(e => e.SolrFieldName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
