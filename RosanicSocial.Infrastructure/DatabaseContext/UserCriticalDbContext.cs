using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Creators;
using RosanicSocial.Application.Interfaces.Factories;
using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.DatabaseContext {
    public class UserCriticalDbContext : DbContext {
        private readonly IDbTableCreatorFactoryService _dbTableCreatorFactory;
        private readonly string _jsonPath = "Jsons/Player/";
        public UserCriticalDbContext(DbContextOptions<UserCriticalDbContext> options, IDbTableCreatorFactoryService dbTableCreatorFactoryService) : base(options) {
            _dbTableCreatorFactory = dbTableCreatorFactoryService;
        }
        public UserCriticalDbContext() { }

        public virtual DbSet<UserPermissionEntity> UserPermissions { get; set; }
        public virtual DbSet<UserBanEntity> UserBans { get; set; }
        public virtual DbSet<UserWarningEntity> UserWarnings { get; set; }
        public virtual DbSet<UserDangerZoneEntity> UserDangerZones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("UserCritical");
            IDbTableCreatorService creator = _dbTableCreatorFactory.Build(_jsonPath, ref modelBuilder);

            creator.AddTable<UserPermissionEntity>("UsersPermissions");
            creator.AddTable<UserBanEntity>("UsersBans");
            creator.AddTable<UserWarningEntity>("UsersWarnings");
            creator.AddTable<UserDangerZoneEntity>("UsersDangerZones");
        }
    }
}
