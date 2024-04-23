using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.Post;
using RosanicSocial.Domain.DTO.Response.Reports.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class PostReportDbService : IPostReportDbService {
        public Task<PostReportEntity> AddPostReport(PostReportEntity entity) {
            throw new NotImplementedException();
        }

        public Task<PostReportDeleteAllResponse> DeleteAllPostReports(PostReportDeleteAllRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostReportDeleteResponse> DeletePostReport(PostReportDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostReportGetResponse> GetPostReport(PostReportGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostReportGetByUserIdResponse> GetPostReportsByUserId(PostReportGetByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostReportUpdateResponse> UpdatePostReport(PostReportUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
