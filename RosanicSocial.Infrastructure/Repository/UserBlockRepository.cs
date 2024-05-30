using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class UserBlockRepository : IUserBlockRepository {
        private readonly ReportsDbContext _db;
        private readonly ILogger<UserBlockRepository> _logger;

        public UserBlockRepository(ReportsDbContext db, ILogger<UserBlockRepository> logger) {
            _db = db;
            _logger = logger;
        }
        public async Task<UserBlockEntity?> AddBlock(UserBlockEntity entity) {
            _logger.LogDebug($"{nameof(AddBlock)} for UserId:{entity.UserId} in {nameof(UserBlockRepository)} is started.");

            await _db.UserBlocks.AddAsync(entity);
            await _db.SaveChangesAsync();

            _logger.LogInformation($"{nameof(AddBlock)} in {nameof(UserBlockRepository)} is finished.");
            return entity;
        }

        public async Task<UserBlockEntity[]> DeleteAllBlocks(int userId) {
            _logger.LogDebug($"{nameof(DeleteAllBlocks)} for UserId:{userId} in {nameof(UserBlockRepository)} is started.");

            UserBlockEntity[] entities = await _db.UserBlocks.Where(be => be.UserId == userId).ToArrayAsync();
            _db.UserBlocks.RemoveRange(entities);
            await _db.SaveChangesAsync();

            _logger.LogDebug($"{nameof(DeleteAllBlocks)} in {nameof(UserBlockRepository)} is finished with {entities.Length} blocks.");
            return entities;
        }

        public async Task<UserBlockEntity?> DeleteBlock(int userId, int blockedId) {
            _logger.LogDebug($"{nameof(DeleteBlock)} for (UserId:{userId} blocked UserId:{blockedId}) in {nameof(UserBlockRepository)} is started.");

            UserBlockEntity? entity = await _db.UserBlocks.SingleOrDefaultAsync(be => be.Id == userId && be.BlockedUserId == blockedId);
            if (entity == null) {
                _logger.LogWarning($"No entity found for {nameof(DeleteBlock)} in {nameof(UserBlockRepository)}, returning null.");
                return null;
            }

            _db.UserBlocks.Remove(entity);
            await _db.SaveChangesAsync();

            _logger.LogDebug($"{nameof(DeleteAllBlocks)} in {nameof(UserBlockRepository)} is finished.");
            return entity;
        }

        public Task<UserBlockEntity[]> GetAllBlocksByUserId(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserBlockEntity?> GetBlock(int userId) {
            throw new NotImplementedException();
        }
    }
}
