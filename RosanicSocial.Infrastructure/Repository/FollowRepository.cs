using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class FollowRepository : IFollowRepository {
        private readonly InteractionDbContext _db;
        public FollowRepository(InteractionDbContext db) {
            _db = db;
        }
        public async Task<FollowsEntity> AddFollows(FollowsEntity entity) {
            await _db.Follows.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<FollowsEntity[]> DeleteAllFollows(int id) {
            FollowsEntity[] entities = await _db.Follows.Where(fe => fe.UserId == id).ToArrayAsync();
            _db.Follows.RemoveRange(entities);
            await _db.SaveChangesAsync();
            return entities;
        }

        public async Task<FollowsEntity?> DeleteFollows(int userId, int followingId) {
            FollowsEntity? entity = await _db.Follows.SingleOrDefaultAsync(fe => fe.UserId == userId && fe.FollowingId == followingId);
            if (entity == null) {
                return null;
            }
            _db.Follows.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<FollowsEntity[]> GetAllFollowers(int id) {
            FollowsEntity[] entities = await _db.Follows.Where(fe => fe.FollowingId==id).ToArrayAsync();
            return entities;
        }

        public async Task<FollowsEntity[]> GetAllFollowings(int id) {
            FollowsEntity[] entities = await _db.Follows.Where(fe => fe.UserId==id).ToArrayAsync();
            return entities;
        }

        public async Task<FollowsEntity?> GetFollows(int userId, int followingId) {
            FollowsEntity? entity = await _db.Follows.SingleOrDefaultAsync(fe => fe.UserId==userId && fe.FollowingId==followingId);
            return entity;
        }

        public Task<FollowsEntity> UpdateFollows(FollowsEntity entity) {
            throw new NotImplementedException();
        }
    }
}
