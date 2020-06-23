using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SystematicsPortal.Data.dbmodels;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystematicsPortal.Data
{
    public partial class NamesWebContext : DbContext
    {
        public NamesWebContext()
        {
        }

        public NamesWebContext(DbContextOptions<NamesWebContext> options)
            : base(options)
        {
        }

        public NamesWebContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public virtual DbSet<NameDocument> NameDocument { get; set; }
        public virtual DbSet<ReferenceDocument> ReferenceDocument { get; set; }
        public virtual DbSet<StaticContentDocument> StaticContentDocument { get; set; }
        public virtual DbSet<VernacularNameDocument> VernacularNameDocument { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NameDocument>(entity =>
            {
                entity.HasKey(e => e.NameId)
                    .HasName("prkNameDocument");

                entity.ToTable("NameDocument", "documents");

                entity.Property(e => e.NameId).ValueGeneratedNever();

                entity.Property(e => e.SerializedDocument)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime2(2)");
                entity.Property(e => e.ValidTo).HasColumnType("datetime2(2)");
            });

            modelBuilder.Entity<ReferenceDocument>(entity =>
            {
                entity.HasKey(e => e.ReferenceId)
                    .HasName("prkReferenceDocument");

                entity.ToTable("ReferenceDocument", "documents");

                entity.Property(e => e.ReferenceId).ValueGeneratedNever();

                entity.Property(e => e.SerializedDocument)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime2(2)");

                entity.Property(e => e.ValidTo).HasColumnType("datetime2(2)");
            });

            modelBuilder.Entity<StaticContentDocument>(entity =>
            {
                entity.HasKey(e => e.StaticContentId)
                    .HasName("prkStaticContentDocument");

                entity.ToTable("StaticContentDocument", "documents");

                entity.Property(e => e.StaticContentId).ValueGeneratedNever();

                entity.Property(e => e.SerializedDocument)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime2(2)");

                entity.Property(e => e.ValidTo).HasColumnType("datetime2(2)");
            });

            modelBuilder.Entity<VernacularNameDocument>(entity =>
            {
                entity.HasKey(e => e.VernacularNameId)
                    .HasName("prkVernacularNameDocument");

                entity.ToTable("VernacularNameDocument", "documents");

                entity.Property(e => e.VernacularNameId).ValueGeneratedNever();

                entity.Property(e => e.SerializedDocument)
                    .IsRequired()
                    .HasColumnType("xml");

                entity.Property(e => e.ValidFrom).HasColumnType("datetime2(2)");

                entity.Property(e => e.ValidTo).HasColumnType("datetime2(2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
