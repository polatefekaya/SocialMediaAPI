using Microsoft.EntityFrameworkCore;
using RosanicSocial.Domain.Models;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.DatabaseContext {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions options) : base(options) {
        }
        public ApplicationDbContext() {

        }
        public virtual DbSet<Rose> Roses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rose>().HasData(new Rose() {
                Id = Guid.Parse("4C5831BA-251D-4A0B-8E46-1157AE4F739E"),
                AuthorUsername = "polatsfekaya",
                Message = "The World is Excellent!",
                PostDate = DateTime.UtcNow,
                StatisticId = Guid.Empty,
                AuthorId = Guid.Parse("EFAF57C1-AB42-498B-BED6-1DBB1980A3FD"),
                NumbersId = Guid.Empty,
            });
        }
    }
}
