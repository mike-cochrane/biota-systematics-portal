using Microsoft.EntityFrameworkCore;
using SystematicsPortal.Model.Models.Database;

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

        public virtual DbSet<Document> Document { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document", "documents");

                entity.Property(e => e.DocumentId).ValueGeneratedNever();

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
