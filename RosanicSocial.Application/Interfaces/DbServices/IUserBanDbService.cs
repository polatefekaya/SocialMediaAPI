using RosanicSocial.Domain.DTO.Request.Reports.Ban;
using RosanicSocial.Domain.DTO.Response.Reports.Ban;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IUserBanDbService {
        Task<BanAddResponse> AddBan(BanAddRequest request);
        Task<BanUpdateResponse> UpdateBan(BanUpdateRequest request);
        Task<BanDeleteResponse> DeleteBan(BanDeleteRequest request);
        Task<BanGetResponse> GetBan(BanGetRequest request);
        Task<BanGetAllByUserIdResponse> GetBansAllByUserId(BanGetAllByUserIdRequest request);
    }
}
