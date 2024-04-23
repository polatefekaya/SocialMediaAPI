using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class UserWarningRepository : IUserWarningRepository {
        public Task<UserWarningEntity> AddUserWarning(UserWarningEntity entity) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<UserWarningEntity>> DeleteAllUserWarnings(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserWarningEntity> DeleteUserWarning(Guid warningId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<UserWarningEntity>> GetAllUserWarningByUserId(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserWarningEntity> GetUserWarning(Guid warningId) {
            throw new NotImplementedException();
        }

        public Task<UserWarningEntity> UpdateUserWarning(UserWarningEntity entity) {
            throw new NotImplementedException();
        }
    }
}
