using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class UserInfoRepository : IUserInfoRepository {
        private readonly InfoDbContext _db;
        private readonly ILogger<UserInfoRepository> _logger;
        public UserInfoRepository(InfoDbContext db, ILogger<UserInfoRepository> logger) {
            _db = db;
            _logger = logger;
        }
        //TODO: Add Logger
        public async Task<BaseInfoEntity> AddBaseInfo(BaseInfoEntity entity) {
            _logger.LogDebug($"{nameof(AddBaseInfo)} for UserId:{entity.UserId} in {nameof(UserInfoRepository)} is started.");

            _logger.LogDebug($"Controlling {nameof(_db.BaseInfos)} db for preventing duplicate records.");
            BaseInfoEntity? dbEntity = await _db.BaseInfos.SingleOrDefaultAsync(i => i.UserId == entity.UserId);

            if (dbEntity is not null) {
                _logger.LogError($"Duplicate is found in {nameof(_db.BaseInfos)}, no additions made, returning the duplicate.");
                return dbEntity;
            }

            await _db.BaseInfos.AddAsync(entity);
            await _db.SaveChangesAsync();

            _logger.LogInformation($"{nameof(AddBaseInfo)} in {nameof(UserInfoRepository)} is finished.");
            return entity;
        }

        public async Task<DetailedInfoEntity> AddDetailedInfo(DetailedInfoEntity entity) {
            _logger.LogDebug($"{nameof(AddDetailedInfo)} for UserId:{entity.UserId} in {nameof(UserInfoRepository)} is started.");

            _logger.LogDebug($"Controlling {nameof(_db.DetailedInfos)} db for preventing duplicate records.");
            DetailedInfoEntity? dbEntity = await _db.DetailedInfos.SingleOrDefaultAsync(i => i.UserId == entity.UserId);

            if (dbEntity is not null) {
                _logger.LogError($"Duplicate is found in {nameof(_db.DetailedInfos)}, no additions made, returning the duplicate.");
                return dbEntity;
            }

            await _db.DetailedInfos.AddAsync(entity);
            await _db.SaveChangesAsync();

            _logger.LogInformation($"{nameof(AddDetailedInfo)} in {nameof(UserInfoRepository)} is finished.");
            return entity;
        }

        public async Task<BaseInfoEntity?> DeleteBaseInfo(int id) {
            _logger.LogDebug($"{nameof(DeleteBaseInfo)} for UserId:{id} in {nameof(UserInfoRepository)} is started.");

            _logger.LogDebug($"Getting the relevant BaseInfo Entity from {nameof(_db.BaseInfos)}.");
            BaseInfoEntity? entity = await _db.BaseInfos.FindAsync(id);

            if (entity is null) {
                _logger.LogError($"No BaseInfo Entity is found for deletions, returning null.");        
                return null;
            }

            _db.BaseInfos.Remove(entity);
            await _db.SaveChangesAsync();

            _logger.LogInformation($"{nameof(DeleteBaseInfo)} in {nameof(UserInfoRepository)} is finished.");
            return entity;
        }

        public async Task<DetailedInfoEntity?> DeleteDetailedInfo(int id) {
            _logger.LogDebug($"{nameof(DeleteDetailedInfo)} for UserId:{id} in {nameof(UserInfoRepository)} is started.");

            _logger.LogDebug($"Getting the relevant DetailedInfo Entity from {nameof(_db.DetailedInfos)}.");
            DetailedInfoEntity? entity = await _db.DetailedInfos.FindAsync(id);

            if (entity is null) {
                _logger.LogError($"No DetailedInfo Entity is found for deletions, returning null.");
                return null; 
            }

            _db.DetailedInfos.Remove(entity);
            await _db.SaveChangesAsync();

            _logger.LogInformation($"{nameof(DeleteDetailedInfo)} in {nameof(UserInfoRepository)} is finished.");
            return entity;
        }

        public async Task<BaseInfoEntity?> GetBaseInfo(int id) {
            _logger.LogDebug($"{nameof(GetBaseInfo)} for UserId:{id} in {nameof(UserInfoRepository)} is started.");

            BaseInfoEntity? entity = await _db.BaseInfos.SingleOrDefaultAsync(i => i.UserId == id);
            if (entity is null) {
                _logger.LogError($"No BaseInfo Entity is found for UserId:{id}, returning null.");
                return null;
            }

            _logger.LogInformation($"{nameof(GetBaseInfo)} in {nameof(UserInfoRepository)} is finished.");
            return entity;
        }

        public async Task<DetailedInfoEntity?> GetDetailedInfo(int id) {
            _logger.LogDebug($"{nameof(GetDetailedInfo)} for UserId:{id} in {nameof(UserInfoRepository)} is started.");

            DetailedInfoEntity? entity = await _db.DetailedInfos.SingleOrDefaultAsync(i => i.UserId == id);
            if (entity is null) {
                _logger.LogError($"No DetailedInfo Entity is found for UserId:{id}, returning null.");
                return null;
            }

            _logger.LogInformation($"{nameof(GetDetailedInfo)} in {nameof(UserInfoRepository)} is finished.");
            return entity;
        }

        public async Task<BaseInfoEntity> UpdateBaseInfo(BaseInfoEntity entity) {
            _logger.LogDebug($"{nameof(UpdateBaseInfo)} for UserId:{entity.UserId} in {nameof(UserInfoRepository)} is started.");

            _db.BaseInfos.Update(entity);
            await _db.SaveChangesAsync();

            _logger.LogInformation($"{nameof(UpdateBaseInfo)} in {nameof(UserInfoRepository)} is finished.");
            return entity;
        }

        public async Task<DetailedInfoEntity> UpdateDetailedInfo(DetailedInfoEntity entity) {
            _logger.LogDebug($"{nameof(UpdateDetailedInfo)} for UserId:{entity.UserId} in {nameof(UserInfoRepository)} is started.");

            _db.DetailedInfos.Update(entity);
            await _db.SaveChangesAsync();

            _logger.LogInformation($"{nameof(UpdateDetailedInfo)} in {nameof(UserInfoRepository)} is finished.");
            return entity;
        }
    }
}
