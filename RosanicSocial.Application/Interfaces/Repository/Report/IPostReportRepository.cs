using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.Post;
using RosanicSocial.Domain.DTO.Response.Reports.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Report
{
    public interface IPostReportRepository
    {
        Task<PostReportEntity> AddPostReport(PostReportEntity entity);
        Task<IQueryable<PostReportEntity>> DeleteAllPostReports(int userId);
        Task<PostReportEntity> DeletePostReport(Guid reportId);
        Task<PostReportEntity> UpdatePostReport(PostReportEntity entity);
        Task<PostReportEntity> GetPostReport(Guid reportId);
        Task<IQueryable<PostReportEntity>> GetPostReportsByUserId(int userId);
    }
}
