using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.Comment;
using RosanicSocial.Domain.DTO.Response.Reports.Comment;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface ICommentReportDbService {
        Task<CommentReportAddResponse> AddCommentReport(CommentReportAddRequest request);
        Task<CommentReportUpdateResponse> UpdateCommentReport(CommentReportUpdateRequest request);
        Task<CommentReportGetResponse> GetCommentReport(CommentReportGetRequest request);
        Task<CommentReportDeleteResponse> DeleteCommentReport(CommentReportDeleteRequest request);
        Task<CommentReportDeleteResponse[]> DeleteAllCommentReports(CommentReportDeleteAllRequest request);
        Task<CommentReportGetResponse[]> GetCommentReportsByUserId(CommentReportGetByUserIdRequest request);
    }
}
