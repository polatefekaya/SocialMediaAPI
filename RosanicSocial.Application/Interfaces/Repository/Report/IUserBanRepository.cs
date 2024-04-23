using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.Ban;
using RosanicSocial.Domain.DTO.Response.Reports.Ban;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Report
{
    public interface IUserBanRepository
    {
        Task<UserBanEntity> AddBan(UserBanEntity entity);
        Task<UserBanEntity> UpdateBan(UserBanEntity entity);
        Task<UserBanEntity> DeleteBan(Guid banId);
        Task<UserBanEntity> GetBan(Guid banId);
        Task<IQueryable<UserBanEntity>> GetAllBansByUserId(int userId);
    }
}
