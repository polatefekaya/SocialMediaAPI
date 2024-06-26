﻿using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.Post;
using RosanicSocial.Domain.DTO.Response.Reports.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IPostReportDbService {
        Task<PostReportAddResponse> AddPostReport(PostReportEntity entity);
        Task<PostReportDeleteResponse[]> DeleteAllPostReports(PostReportDeleteAllRequest request);
        Task<PostReportDeleteResponse> DeletePostReport(PostReportDeleteRequest request);
        Task<PostReportUpdateResponse> UpdatePostReport(PostReportUpdateRequest request);
        Task<PostReportGetResponse> GetPostReport(PostReportGetRequest request);
        Task<PostReportGetResponse[]> GetPostReportsByUserId(PostReportGetByUserIdRequest request);
    }
}
