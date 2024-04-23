using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Reports.DangerZone;
using RosanicSocial.Domain.DTO.Response.Reports.DangerZone;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class UserDangerZoneDbService : IUserDangerZoneDbService {
        public Task<DangerzoneAddResponse> AddDangerzone(DangerzoneAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<DangerzoneDeleteResponse> DeleteDangerzone(DangerzoneDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<DangerzoneGetResponse> GetDangerzone(DangerzoneGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<DangerzoneUpdateResponse> UpdateDangerzone(DangerzoneUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
