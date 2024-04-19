using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Request.Info.Detailed;
using RosanicSocial.Domain.DTO.Response.Info.Base;
using RosanicSocial.Domain.DTO.Response.Info.Detailed;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class UserInfoDbService : IUserInfoDbService {
        public Task<BaseInfoAddResponse> AddBaseInfo(BaseInfoAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<DetailedInfoAddResponse> AddDetailedInfo(DetailedInfoAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<BaseInfoDeleteResponse> DeleteBaseInfo(BaseInfoDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<DetailedInfoDeleteResponse> DeleteDetailedInfo(DetailedInfoDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<BaseInfoGetResponse> GetBaseInfo(BaseInfoGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<DetailedInfoGetResponse> GetDetailedInfo(DetailedInfoGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<BaseInfoUpdateResponse> UpdateBaseInfo(BaseInfoUpdateRequest request) {
            throw new NotImplementedException();
        }

        public Task<DetailedInfoUpdateResponse> UpdateDetailedInfo(DetailedInfoUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
