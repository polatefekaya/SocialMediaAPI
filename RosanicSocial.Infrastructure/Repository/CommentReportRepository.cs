using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class CommentReportRepository : ICommentReportRepository {
        public Task<CommentReportEntity> AddCommentReport(CommentReportEntity entity) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<CommentReportEntity>> DeleteAllCommentReports(int userId) {
            throw new NotImplementedException();
        }

        public Task<CommentReportEntity> DeleteCommentReport(Guid reportId) {
            throw new NotImplementedException();
        }

        public Task<CommentReportEntity> GetCommentReport(Guid reportId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<CommentReportEntity>> GetCommentReportsByUserId(int userId) {
            throw new NotImplementedException();
        }

        public Task<CommentReportEntity> UpdateCommentReport(CommentReportEntity entity) {
            throw new NotImplementedException();
        }
    }
}
