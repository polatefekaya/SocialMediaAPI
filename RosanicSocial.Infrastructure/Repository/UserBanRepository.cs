using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class UserBanRepository : IUserBanRepository {
        public Task<UserBanEntity> AddBan(UserBanEntity entity) {
            throw new NotImplementedException();
        }

        public Task<UserBanEntity> DeleteBan(Guid banId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<UserBanEntity>> GetAllBansByUserId(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserBanEntity> GetBan(Guid banId) {
            throw new NotImplementedException();
        }

        public Task<UserBanEntity> UpdateBan(UserBanEntity entity) {
            throw new NotImplementedException();
        }
    }
}
