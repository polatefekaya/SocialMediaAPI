using Microsoft.EntityFrameworkCore.ChangeTracking;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository
{
    public class RoseRepository : IPostRepository {
        private readonly ApplicationDbContext _dbContext;
        public RoseRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<RoseEntity> AddRose(RoseEntity rose) {
            await _dbContext.Roses.AddAsync(rose);
            await _dbContext.SaveChangesAsync();
            return rose;
        }

        public async Task<RoseEntity> DeleteRose(RoseEntity rose) {
            _dbContext.Roses.Remove(rose);
            await _dbContext.SaveChangesAsync();
            return rose;
        }

        public async Task<RoseEntity> GetRoseById(Guid id) {
            RoseEntity? rose = await _dbContext.Roses.FindAsync(id);
            await _dbContext.SaveChangesAsync();
            if (rose is null) throw new ArgumentNullException();

            return rose;
        }

        public async Task<RoseEntity> UpdateRose(RoseEntity rose) {
            EntityEntry<RoseEntity> trackedRose = _dbContext.Roses.Update(rose);
            await _dbContext.SaveChangesAsync();
            return trackedRose.Entity; 
        }
    }
}
