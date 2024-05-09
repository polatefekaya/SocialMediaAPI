using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class UserInfoRepository : IUserInfoRepository {
        private readonly InfoDbContext _db;
        public UserInfoRepository(InfoDbContext db) {
            _db = db;
        }
        //TODO: Add Logger
        public async Task<BaseInfoEntity> AddBaseInfo(BaseInfoEntity entity) {
            await _db.BaseInfos.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<DetailedInfoEntity> AddDetailedInfo(DetailedInfoEntity entity) {
            await _db.DetailedInfos.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<BaseInfoEntity?> DeleteBaseInfo(int id) {
            BaseInfoEntity? entity = await _db.BaseInfos.FindAsync(id);
            if (entity == null) { return null; }

            _db.BaseInfos.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<DetailedInfoEntity?> DeleteDetailedInfo(int id) {
            DetailedInfoEntity? entity = await _db.DetailedInfos.FindAsync(id);
            if (entity == null) { return null; }

            _db.DetailedInfos.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<BaseInfoEntity?> GetBaseInfo(int id) {
            BaseInfoEntity? entity = await _db.BaseInfos.SingleOrDefaultAsync(i => i.UserId == id);
            return entity;
        }

        public async Task<DetailedInfoEntity> GetDetailedInfo(int id) {
            DetailedInfoEntity? entity = await _db.DetailedInfos.SingleOrDefaultAsync(i => i.UserId == id);
            return entity;
        }

        public async Task<BaseInfoEntity> UpdateBaseInfo(BaseInfoEntity entity) {
            _db.BaseInfos.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<DetailedInfoEntity> UpdateDetailedInfo(DetailedInfoEntity entity) {
            _db.DetailedInfos.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
