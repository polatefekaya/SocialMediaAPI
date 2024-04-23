using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.UserWarning;
using RosanicSocial.Domain.DTO.Response.Reports.UserWarning;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Report
{
    public interface IUserWarningRepository
    {
        Task<UserWarningEntity> AddUserWarning(UserWarningEntity entity);
        Task<UserWarningEntity> GetUserWarning(Guid warningId);
        Task<IQueryable<UserWarningEntity>> GetAllUserWarningByUserId(int userId);
        Task<UserWarningEntity> UpdateUserWarning(UserWarningEntity entity);
        Task<IQueryable<UserWarningEntity>> DeleteAllUserWarnings(int userId);
        Task<UserWarningEntity> DeleteUserWarning(Guid warningId);
    }
}
