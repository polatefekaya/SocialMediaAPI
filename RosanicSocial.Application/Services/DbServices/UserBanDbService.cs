using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Reports.Ban;
using RosanicSocial.Domain.DTO.Response.Reports.Ban;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class UserBanDbService : IUserBanDbService {
        public Task<BanAddResponse> AddBan(BanAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<BanDeleteResponse> DeleteBan(BanDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<BanGetResponse> GetBan(BanGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<BanGetAllByUserIdResponse> GetBansAllByUserId(BanGetAllByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<BanUpdateResponse> UpdateBan(BanUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
