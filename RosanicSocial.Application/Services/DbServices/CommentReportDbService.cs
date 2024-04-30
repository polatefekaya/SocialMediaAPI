using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.Comment;
using RosanicSocial.Domain.DTO.Response.Reports.Comment;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class CommentReportDbService : ICommentReportDbService {
        public Task<CommentReportEntity> AddCommentReport(CommentReportEntity entity) {
            throw new NotImplementedException();
        }

        public Task<CommentReportAddResponse> AddCommentReport(CommentReportAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentReportDeleteResponse[]> DeleteAllCommentReports(CommentReportDeleteAllRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentReportDeleteResponse> DeleteCommentReport(CommentReportDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentReportGetResponse> GetCommentReport(CommentReportGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentReportGetResponse[]> GetCommentReportsByUserId(CommentReportGetByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentReportUpdateResponse> UpdateCommentReport(CommentReportUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
