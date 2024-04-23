using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.Post;
using RosanicSocial.Domain.DTO.Response.Reports.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosanicSocial.Application.Interfaces.DbServices {
    internal interface IPostReportDbService {
        Task<PostReportEntity> AddPostReport(PostReportEntity entity);
        Task<PostReportDeleteAllResponse> DeleteAllPostReports(PostReportDeleteAllRequest request);
        Task<PostReportDeleteResponse> DeletePostReport(PostReportDeleteRequest request);
        Task<PostReportUpdateResponse> UpdatePostReport(PostReportUpdateRequest request);
        Task<PostReportGetResponse> GetPostReport(PostReportGetRequest request);
        Task<PostReportGetByUserIdResponse> GetPostReportsByUserId(PostReportGetByUserIdRequest request);
    }
}
