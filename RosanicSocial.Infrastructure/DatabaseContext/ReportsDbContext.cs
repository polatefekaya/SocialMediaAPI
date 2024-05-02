using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Creators;
using RosanicSocial.Application.Interfaces.Factories;
using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.DatabaseContext {
    public class ReportsDbContext : DbContext {
        private readonly IDbTableCreatorFactoryService _dbTableCreatorFactory;
        private readonly string _jsonPath = "Jsons/Player/";
        public ReportsDbContext(DbContextOptions<ReportsDbContext> options, IDbTableCreatorFactoryService dbTableCreatorFactoryService) : base(options) {
            _dbTableCreatorFactory = dbTableCreatorFactoryService;
        }
        public ReportsDbContext() { }
        public virtual DbSet<CommentReportEntity> CommentReports { get; set; }
        public virtual DbSet<PostReportEntity> PostReports { get; set; }
        public virtual DbSet<UserReportEntity> UserReports { get; set; }
        public virtual DbSet<UserBlockEntity> UserBlocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Reports");
            IDbTableCreatorService creator = _dbTableCreatorFactory.Build(_jsonPath, ref modelBuilder);

            creator.AddTable<CommentReportEntity>("CommentReports");
            creator.AddTable<PostReportEntity>("PostReports");
            creator.AddTable<UserReportEntity>("UserReports");
            creator.AddTable<UserBlockEntity>("UserBlocks");
        }
    }
}
