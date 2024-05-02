using Microsoft.EntityFrameworkCore;
using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class CommentReportRepository : ICommentReportRepository {
        private readonly ReportsDbContext _db;

        public CommentReportRepository(ReportsDbContext db) {
            _db = db;
        }
        public async Task<CommentReportEntity> AddCommentReport(CommentReportEntity entity) {
            await _db.CommentReports.AddAsync(entity);
            return entity;
        }

        public async Task<IQueryable<CommentReportEntity>> DeleteAllCommentReports(int userId) {
           CommentReportEntity[] commentReportEntities = await _db.CommentReports
                .Where(c => c.UserId.Equals(userId)).ToArrayAsync();
            _db.CommentReports.RemoveRange(commentReportEntities);
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
