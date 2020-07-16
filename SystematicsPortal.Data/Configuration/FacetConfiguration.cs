﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystematicsPortal.Models.Entities.Database;

namespace SystematicsPortal.Data.Configuration
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
