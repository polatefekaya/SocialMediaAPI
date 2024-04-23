using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class CommentReportDbService : ICommentReportDbService {
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
