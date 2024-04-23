using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.Comment;
using RosanicSocial.Domain.DTO.Response.Reports.Comment;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Report
{
    public interface ICommentReportRepository
    {
        Task<CommentReportEntity> AddCommentReport(CommentReportEntity entity);
        Task<CommentReportEntity> UpdateCommentReport(CommentReportEntity entity);
        Task<CommentReportEntity> GetCommentReport(Guid reportId);
        Task<CommentReportEntity> DeleteCommentReport(Guid reportId);
        Task<IQueryable<CommentReportEntity>> DeleteAllCommentReports(int userId);
        Task<IQueryable<CommentReportEntity>> GetCommentReportsByUserId(int userId);
    }
}
