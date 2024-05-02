using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Creators;
using RosanicSocial.Application.Interfaces.Factories;
using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.DatabaseContext {
    public class SharingsDbContext : DbContext {
        private readonly IDbTableCreatorFactoryService _dbTableCreatorFactory;
        private readonly string _jsonPath = "Jsons/Player/";
        public SharingsDbContext(DbContextOptions<SharingsDbContext> options, IDbTableCreatorFactoryService dbTableCreatorFactoryService) : base(options) {
            _dbTableCreatorFactory = dbTableCreatorFactoryService;
        }
        public SharingsDbContext() { }

        public virtual DbSet<PostEntity> Posts { get; set; }
        public virtual DbSet<CommentEntity> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Sharings");
            IDbTableCreatorService creator = _dbTableCreatorFactory.Build(_jsonPath, ref modelBuilder);
            
            creator.AddTable<PostEntity>("Posts");
            creator.AddTable<CommentEntity>("Comments");
        }
    }
}
