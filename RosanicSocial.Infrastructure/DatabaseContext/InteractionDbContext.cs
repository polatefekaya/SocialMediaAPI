using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Creators;
using RosanicSocial.Application.Interfaces.Factories;
using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.DatabaseContext {
    public class InteractionDbContext : DbContext {
        private readonly IDbTableCreatorFactoryService _dbTableCreatorFactory;
        private readonly string _jsonPath = "Jsons/Player/";
        public InteractionDbContext(DbContextOptions<InteractionDbContext> options, IDbTableCreatorFactoryService dbTableCreatorFactory) : base(options) {
            _dbTableCreatorFactory = dbTableCreatorFactory;
        }
        public InteractionDbContext() { }
        public virtual DbSet<PostLikesEntity> PostLikes { get; set; }  
        public virtual DbSet<CommentLikesEntity> CommentLikes { get; set; }
        public virtual DbSet<PostSeenEntity> PostSeens { get; set; }
        public virtual DbSet<ProfileSeenEntity> ProfileSeens { get; set; }
        public virtual DbSet<FollowsEntity> Follows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Interactions");
            IDbTableCreatorService creator = _dbTableCreatorFactory.Build(_jsonPath, ref modelBuilder);

            //creator.AddTableWithSeed<PostLikesEntity>("PostLikes");
            creator.AddTable<PostLikesEntity>("PostLikes");
            creator.AddTable<CommentLikesEntity>("CommentLikes");
            creator.AddTable<PostSeenEntity>("PostSeens");
            creator.AddTable<ProfileSeenEntity>("ProfileSeens");
            creator.AddTable<FollowsEntity>("Follows");
        }
    }
}
