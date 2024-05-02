using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Creators;
using RosanicSocial.Application.Interfaces.Factories;
using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.DatabaseContext {
    public class StatisticsDbContext : DbContext {
        private readonly IDbTableCreatorFactoryService _dbTableCreatorFactory;
        private readonly string _jsonPath = "Jsons/Player/";
        public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options, IDbTableCreatorFactoryService dbTableCreatorFactoryService) : base(options) {
            _dbTableCreatorFactory = dbTableCreatorFactoryService;
        }
        public StatisticsDbContext() { }

        public virtual DbSet<CommentStatisticsEntity> CommentStatistics { get; set; }
        public virtual DbSet<PostStatisticsEntity> PostStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Statistics");
            IDbTableCreatorService creator = _dbTableCreatorFactory.Build(_jsonPath, ref modelBuilder);

            creator.AddTable<CommentStatisticsEntity>("CommentStatistics");
            creator.AddTable<PostStatisticsEntity>("PostStatistics");
        }
    }
}
