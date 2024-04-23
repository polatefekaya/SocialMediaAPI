using RosanicSocial.Domain.Data.Entities.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosanicSocial.Application.Interfaces.DbServices {
    internal interface ICommentReportDbService {
        Task<CommentReportEntity> AddCommentReport(CommentReportEntity entity);
        Task<CommentReportEntity> UpdateCommentReport(CommentReportEntity entity);
        Task<CommentReportEntity> GetCommentReport(Guid reportId);
        Task<CommentReportEntity> DeleteCommentReport(Guid reportId);
        Task<IQueryable<CommentReportEntity>> DeleteAllCommentReports(int userId);
        Task<IQueryable<CommentReportEntity>> GetCommentReportsByUserId(int userId);
    }
}
