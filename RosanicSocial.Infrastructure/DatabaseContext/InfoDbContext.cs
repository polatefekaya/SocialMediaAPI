using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RosanicSocial.Application.Interfaces.Factories;
using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.DatabaseContext
{
    public class InfoDbContext : DbContext {
        private readonly string _jsonPath = "Jsons/Player/";
        private readonly IDbTableCreatorFactoryService _tableCreatorFactory;

        public InfoDbContext(DbContextOptions<InfoDbContext> options, IDbTableCreatorFactoryService tableCreatorFactory) : base(options) {
            _tableCreatorFactory = tableCreatorFactory;
        }
        public InfoDbContext() { }
        public virtual DbSet<BaseInfoEntity> BaseInfos { get; set; }
        public virtual DbSet<DetailedInfoEntity> DetailedInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Infos");
            //IDbTableCreatorService creator = _tableCreatorFactory.Build(_jsonPath, ref modelBuilder);

            //modelBuilder.Entity<BaseInfoEntity>().HasMany(e => e.FollowerCount).HasForeignKey(e => e.UserId);
            modelBuilder.Entity<BaseInfoEntity>().ToTable("BaseInfos");
            modelBuilder.Entity<DetailedInfoEntity>().ToTable("DetailedInfos");
            //creator.AddTable<BaseInfoEntity>("BaseInfos");
            //creator.AddTable<DetailedInfoEntity>("DetailedInfos");
        }
    }
}
