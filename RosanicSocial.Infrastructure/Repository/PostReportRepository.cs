using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class PostReportRepository : IPostReportRepository {
        public Task<PostReportEntity> AddPostReport(PostReportEntity entity) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PostReportEntity>> DeleteAllPostReports(int userId) {
            throw new NotImplementedException();
        }

        public Task<PostReportEntity> DeletePostReport(Guid reportId) {
            throw new NotImplementedException();
        }

        public Task<PostReportEntity> GetPostReport(Guid reportId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PostReportEntity>> GetPostReportsByUserId(int userId) {
            throw new NotImplementedException();
        }

        public Task<PostReportEntity> UpdatePostReport(PostReportEntity entity) {
            throw new NotImplementedException();
        }
    }
}
