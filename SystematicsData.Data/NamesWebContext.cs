using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SystematicsData.Data.Models;

namespace SystematicsData.Data
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

        public virtual DbSet<ContentConfiguration> ContentConfigurations { get; set; }

        public virtual DbSet<Document> Documents { get; set; }

        public virtual DbSet<Facet> Facets { get; set; }

        public virtual DbSet<FieldConfiguration> FieldConfigurations { get; set; }

        public virtual DbSet<FieldGroup> FieldGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
