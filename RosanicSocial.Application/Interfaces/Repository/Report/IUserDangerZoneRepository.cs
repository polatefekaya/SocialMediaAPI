using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.DangerZone;
using RosanicSocial.Domain.DTO.Response.Reports.DangerZone;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Report
{
    public interface IUserDangerZoneRepository
    {
        Task<UserDangerZoneEntity> AddDangerzone(UserDangerZoneEntity entity);
        Task<UserDangerZoneEntity> GetDangerzone(int userId);
        Task<UserDangerZoneEntity> DeleteDangerzone(int userId);
        Task<UserDangerZoneEntity> UpdateDangerzone(UserDangerZoneEntity entity);
    }
}
