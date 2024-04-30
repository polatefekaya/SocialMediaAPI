using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Reports.Block;
using RosanicSocial.Domain.DTO.Response.Reports.Block;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class UserBlockDbService : IUserBlockDbService {
        public Task<BlockAddResponse> AddBlock(BlockAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<BlockDeleteResponse[]> DeleteAllBlocks(BlockDeleteAllRequest request) {
            throw new NotImplementedException();
        }

        public Task<BlockDeleteResponse> DeleteBlock(BlockDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<BlockGetResponse[]> GetBlocks(BlockGetRequest request) {
            throw new NotImplementedException();
        }
    }
}
