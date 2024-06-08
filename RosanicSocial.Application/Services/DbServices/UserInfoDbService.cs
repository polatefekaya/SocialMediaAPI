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
            _logger.LogDebug($"{nameof(AddBaseInfo)} in {nameof(UserInfoDbService)} is started.");
            BaseInfoEntity entity = request.ToEntity();

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = entity.CreatedAt;

            entity = await _repo.AddBaseInfo(entity);
            return entity.ToAddResponse();
        }

        public async Task<DetailedInfoAddResponse> AddDetailedInfo(DetailedInfoAddRequest request) {
            DetailedInfoEntity entity = request.ToEntity();

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = entity.CreatedAt;
            
            entity = await _repo.AddDetailedInfo(entity);
            return entity.ToAddResponse();
        }

        public async Task<BaseInfoDeleteResponse?> DeleteBaseInfo(BaseInfoDeleteRequest request) {
            BaseInfoEntity? entity = await _repo.DeleteBaseInfo(request.UserId);
            if (entity == null) { return null; }

            BaseInfoDeleteResponse response = entity.ToDeleteResponse();
            return response;
        }

        public async Task<DetailedInfoDeleteResponse?> DeleteDetailedInfo(DetailedInfoDeleteRequest request) {
            DetailedInfoEntity? entity = await _repo.DeleteDetailedInfo(request.UserId);
            if (entity == null) { return null; }

            DetailedInfoDeleteResponse response = entity.ToDeleteResponse();
            return response;
        }

        public async Task<BaseInfoGetResponse?> GetBaseInfo(BaseInfoGetRequest request) {
            BaseInfoEntity? entity = await _repo.GetBaseInfo(request.UserId);
            if (entity == null) { return null; }

            BaseInfoGetResponse response = entity.ToGetResponse();
            return response;
        }

        public async Task<DetailedInfoGetResponse?> GetDetailedInfo(DetailedInfoGetRequest request) {
            DetailedInfoEntity? entity = await _repo.GetDetailedInfo(request.UserId);
            if (entity == null) { return null; }

            DetailedInfoGetResponse response = entity.ToGetResponse();
            return response;
        }

        public async Task<BaseInfoUpdateResponse?> UpdateBaseInfo(BaseInfoUpdateRequest request) {
            BaseInfoEntity entity = request.ToEntity();
            entity.UpdatedAt = DateTime.UtcNow;

            return await baseUpdater(entity);
        }

        public async Task<BaseInfoUpdateResponse?> UpdateBaseInfoPostCount(BaseInfoUpdatePostCountRequest request) {
            BaseInfoEntity? entity = await _repo.GetBaseInfo(request.UserId);
            if (entity == null) { return null; }

            entity.PostCount += request.Change;
            entity.UpdatedAt = DateTime.UtcNow;

            return await baseUpdater(entity);
        }

        public async Task<BaseInfoUpdateResponse?> UpdateBaseInfoFollowerCount(BaseInfoUpdateFollowCountRequest request) {
            BaseInfoEntity? entity = await _repo.GetBaseInfo(request.UserId);
            if (entity == null) { return null; }

            entity.FollowerCount += request.Change;
            entity.UpdatedAt = DateTime.UtcNow;

            return await baseUpdater(entity);
        }

        public async Task<BaseInfoUpdateResponse?> UpdateBaseInfoFollowingCount(BaseInfoUpdateFollowCountRequest request) {
            BaseInfoEntity? entity = await _repo.GetBaseInfo(request.UserId);
            if (entity == null) { return null; }

            entity.FollowingCount += request.Change;
            entity.UpdatedAt = DateTime.UtcNow;

            return await baseUpdater(entity);
        }

        public async Task<DetailedInfoUpdateResponse?> UpdateDetailedInfo(DetailedInfoUpdateRequest request) {
            DetailedInfoEntity entity = request.ToEntity();
            entity.UpdatedAt = DateTime.UtcNow;

            DetailedInfoEntity updatedEntity = await _repo.UpdateDetailedInfo(entity);
            DetailedInfoUpdateResponse response = updatedEntity.ToUpdateResponse();
            return response;
        }

        private async Task<BaseInfoUpdateResponse?> baseUpdater(BaseInfoEntity entity) {
            BaseInfoEntity updatedEntity = await _repo.UpdateBaseInfo(entity);
            BaseInfoUpdateResponse response = updatedEntity.ToUpdateResponse();
            return response;
        }
    }
}
