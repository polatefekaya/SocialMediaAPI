using RosanicSocial.Domain.DTO.Request.Reports.Block;
using RosanicSocial.Domain.DTO.Response.Reports.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosanicSocial.Application.Interfaces.DbServices {
    internal interface IUserBlockDbService {
        Task<BlockAddResponse> AddBlock(BlockAddRequest request);
        Task<BlockDeleteResponse> DeleteBlock(BlockDeleteRequest request);
        Task<BlockDeleteAllResponse> DeleteAllBlocks(BlockDeleteAllRequest request);
        Task<IQueryable<BlockGetResponse>> GetBlocks(BlockGetRequest request);
    }
}
