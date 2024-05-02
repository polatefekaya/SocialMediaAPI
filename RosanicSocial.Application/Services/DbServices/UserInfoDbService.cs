using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Request.Info.Detailed;
using RosanicSocial.Domain.DTO.Response.Info.Base;
using RosanicSocial.Domain.DTO.Response.Info.Detailed;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class UserInfoDbService : IUserInfoDbService {
        private readonly ILogger<UserInfoDbService> _logger;
        private readonly IUserInfoRepository _repo;
        public UserInfoDbService(ILogger<UserInfoDbService> logger, IUserInfoRepository repo) {
            _logger = logger;
            _repo = repo;
        }
        public async Task<BaseInfoAddResponse> AddBaseInfo(BaseInfoAddRequest request) {
            _logger.LogInformation($"Add BaseInfo Add request: {request}");
            BaseInfoEntity entity = request.ToEntity();
            entity = await _repo.AddBaseInfo(entity);
            return entity.ToAddResponse();
        }

        public async Task<DetailedInfoAddResponse> AddDetailedInfo(DetailedInfoAddRequest request) {
            throw new NotImplementedException();
        }

        public async Task<BaseInfoDeleteResponse> DeleteBaseInfo(BaseInfoDeleteRequest request) {
            throw new NotImplementedException();
        }

        public async Task<DetailedInfoDeleteResponse> DeleteDetailedInfo(DetailedInfoDeleteRequest request) {
            throw new NotImplementedException();
        }

        public async Task<BaseInfoGetResponse> GetBaseInfo(BaseInfoGetRequest request) {
            throw new NotImplementedException();
        }

        public async Task<DetailedInfoGetResponse> GetDetailedInfo(DetailedInfoGetRequest request) {
            throw new NotImplementedException();
        }

        public async Task<BaseInfoUpdateResponse> UpdateBaseInfo(BaseInfoUpdateRequest request) {
            throw new NotImplementedException();
        }

        public async Task<DetailedInfoUpdateResponse> UpdateDetailedInfo(DetailedInfoUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
