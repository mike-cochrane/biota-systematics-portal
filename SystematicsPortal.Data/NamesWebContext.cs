﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SystematicsPortal.Models.Entities.Database;

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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
