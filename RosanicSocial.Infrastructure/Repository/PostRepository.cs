using Microsoft.EntityFrameworkCore.ChangeTracking;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository
{
    public class PostRepository : IPostRepository {
        private readonly ApplicationDbContext _dbContext;
        public PostRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<PostEntity> AddRose(PostEntity rose) {
            await _dbContext.Roses.AddAsync(rose);
            await _dbContext.SaveChangesAsync();
            return rose;
        }

        public async Task<PostEntity> DeleteRose(PostEntity rose) {
            _dbContext.Roses.Remove(rose);
            await _dbContext.SaveChangesAsync();
            return rose;
        }

        public async Task<PostEntity> GetRoseById(Guid id) {
            PostEntity? rose = await _dbContext.Roses.FindAsync(id);
            await _dbContext.SaveChangesAsync();
            if (rose is null) throw new ArgumentNullException();

            return rose;
        }

        public async Task<PostEntity> UpdateRose(PostEntity rose) {
            EntityEntry<PostEntity> trackedRose = _dbContext.Roses.Update(rose);
            await _dbContext.SaveChangesAsync();
            return trackedRose.Entity; 
        }
    }
}
