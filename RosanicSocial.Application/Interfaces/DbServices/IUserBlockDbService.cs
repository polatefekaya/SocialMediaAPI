using RosanicSocial.Domain.DTO.Request.Reports.Block;
using RosanicSocial.Domain.DTO.Response.Reports.Block;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IUserBlockDbService {
        Task<BlockAddResponse?> AddBlock(BlockAddRequest request);
        Task<BlockDeleteResponse?> DeleteBlock(BlockDeleteRequest request);
        Task<BlockDeleteResponse[]> DeleteAllBlocks(BlockDeleteAllRequest request);
        Task<BlockGetResponse[]> GetBlocks(BlockGetAllRequest request);
        Task<BlockGetResponse?> GetBlock(BlockGetRequest request);
    }
}
