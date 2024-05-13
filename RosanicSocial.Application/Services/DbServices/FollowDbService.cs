using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities;
using RosanicSocial.Domain.DTO.Request.Follows;
using RosanicSocial.Domain.DTO.Response.Follows;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class FollowDbService : IFollowDbService {
        private readonly IFollowRepository _repo;
        private readonly ILogger<FollowDbService> _logger;
        private readonly EntityConvertService _converter;

        public FollowDbService(IFollowRepository repo, ILogger<FollowDbService> logger, EntityConvertService converter) {
            _repo = repo;
            _logger = logger;
            _converter = converter;
        }

        public async Task<FollowsAddResponse> AddFollow(FollowsAddRequest request) {
            _logger.LogInformation("AddFollow method is started in FollowDbService");
            FollowsEntity entity = request.ToEntity();

            entity = await _repo.AddFollows(entity);
            FollowsAddResponse response = entity.ToAddResponse();
            return response;    
        }

        public async Task<FollowsDeleteResponse[]> DeleteAllFollows(FollowsDeleteAllRequest request) {
            _logger.LogInformation("DeleteAllFollows method is started in FollowDbService");

            FollowsEntity[] entities = await _repo.DeleteAllFollows(request.UserId);
            FollowsDeleteResponse[] responses = await _converter.ToResponseAsync(entities, e => {
                return e.ToDeleteResponse();
            });
            return responses;
        }

        public async Task<FollowsDeleteResponse?> DeleteFollow(FollowsDeleteRequest request) {
            _logger.LogInformation("DeleteFollow method is started in FollowDbService");

            FollowsEntity? entity = await _repo.DeleteFollows(request.UserId, request.FollowingId);
            if (entity == null) { return null; }
            return entity.ToDeleteResponse();
        }

        public async Task<FollowsGetResponse?> GetFollow(FollowsGetIsFollowingRequest request) {
            _logger.LogInformation("GetFollow method is started in FollowDbService");

            FollowsEntity? entity = await _repo.GetFollows(request.UserId, request.FollowerId);
            if (entity == null) { return null; }
            return entity.ToGetResponse();
        }

        public async Task<FollowsGetResponse[]> GetFollowers(FollowsGetFollowersRequest request) {
            _logger.LogInformation("GetFollowers method is started in FollowDbService");

            FollowsEntity[] entities = await _repo.GetAllFollowers(request.UserId);
            FollowsGetResponse[] responses = await _converter.ToResponseAsync(entities, e => {
                return e.ToGetResponse();
            });
            return responses;
        }

        public async Task<FollowsGetResponse[]> GetFollowings(FollowsGetFollowingsRequest request) {
            _logger.LogInformation("GetFollowings method is started in FollowDbService");

            FollowsEntity[] entities = await _repo.GetAllFollowings(request.UserId);
            FollowsGetResponse[] responses = await _converter.ToResponseAsync(entities, e => {
                return e.ToGetResponse();
            });
            return responses;
        }
    }
}
