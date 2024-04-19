using Microsoft.EntityFrameworkCore;
using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions options) : base(options) {
        }
        public ApplicationDbContext() {

        }
        public virtual DbSet<PostEntity> Roses { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<PostEntity>().HasData(new PostEntity() {
        //        Id = 1,
        //        Message = "The World is Excellent!",
        //        StatisticId = Guid.Empty,
        //        AuthorId = Guid.Parse("EFAF57C1-AB42-498B-BED6-1DBB1980A3FD"),
        //        NumbersId = Guid.Empty
        //    });
        //}
    }
}
