using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.Block;
using RosanicSocial.Domain.DTO.Response.Reports.Block;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Report
{
    public interface IUserBlockRepository
    {
        Task<UserBlockEntity?> AddBlock(UserBlockEntity entity);
        Task<UserBlockEntity?> DeleteBlock(int userId, int blockedId);
        Task<UserBlockEntity[]> DeleteAllBlocks(int userId);
        Task<UserBlockEntity[]> GetAllBlocksByUserId(int userId);
        Task<UserBlockEntity?> GetBlock(int userId, int blockedId);
    }
}
