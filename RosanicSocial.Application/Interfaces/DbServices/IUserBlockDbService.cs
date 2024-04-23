using RosanicSocial.Domain.DTO.Request.Reports.Block;
using RosanicSocial.Domain.DTO.Response.Reports.Block;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IUserBlockDbService {
        Task<BlockAddResponse> AddBlock(BlockAddRequest request);
        Task<BlockDeleteResponse> DeleteBlock(BlockDeleteRequest request);
        Task<BlockDeleteAllResponse> DeleteAllBlocks(BlockDeleteAllRequest request);
        Task<IQueryable<BlockGetResponse>> GetBlocks(BlockGetRequest request);
    }
}
