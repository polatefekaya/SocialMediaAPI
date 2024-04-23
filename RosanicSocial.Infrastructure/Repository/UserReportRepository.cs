using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class UserReportRepository : IUserReportRepository {
        public Task<UserReportEntity> AddUserReport(UserReportEntity entity) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<UserReportEntity>> DeleteAllUserReports(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserReportEntity> DeleteUserReport(Guid reportId) {
            throw new NotImplementedException();
        }

        public Task<UserReportEntity> GetUserReport(Guid reportId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<UserReportEntity>> GetUserReportsByUserId(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserReportEntity> UpdateUserReport(UserReportEntity entity) {
            throw new NotImplementedException();
        }
    }
}
