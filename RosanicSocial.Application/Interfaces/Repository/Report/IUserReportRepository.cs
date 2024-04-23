using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.UserReport;
using RosanicSocial.Domain.DTO.Response.Reports.UserReport;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Report
{
    public interface IUserReportRepository
    {
        Task<UserReportEntity> AddUserReport(UserReportEntity entity);
        //ByReportId
        Task<UserReportEntity> GetUserReport(Guid reportId);
        Task<IQueryable<UserReportEntity>> GetUserReportsByUserId(int userId);
        Task<UserReportEntity> UpdateUserReport(UserReportEntity entity);
        Task<UserReportEntity> DeleteUserReport(Guid reportId);
        Task<IQueryable<UserReportEntity>> DeleteAllUserReports(int userId);
    }
}
