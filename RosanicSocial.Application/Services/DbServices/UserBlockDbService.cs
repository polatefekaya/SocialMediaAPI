using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.Block;
using RosanicSocial.Domain.DTO.Response.Reports.Block;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class UserBlockDbService : IUserBlockDbService {
        private readonly IUserBlockRepository _repo;
        private readonly ILogger<UserBlockDbService> _logger;
        private readonly IEntityConvertService _converter;

        public UserBlockDbService(IUserBlockRepository repo, ILogger<UserBlockDbService> logger, IEntityConvertService converter) {
            _repo = repo;
            _logger = logger;
            _converter = converter;
        }

        public async Task<BlockAddResponse?> AddBlock(BlockAddRequest request) {
            _logger.LogDebug($"{nameof(AddBlock)} in {nameof(UserBlockDbService)} is started.");
            UserBlockEntity? entity = request.ToEntity();

            entity.CreatedAt = DateTime.UtcNow;

            _logger.LogInformation($"{nameof(_repo.AddBlock)} in {nameof(IUserBlockRepository)} is starting.");
            entity = await _repo.AddBlock(entity);

            BlockAddResponse response = entity.ToAddResponse();

            _logger.LogInformation($"{nameof(AddBlock)} in {nameof(UserBlockDbService)} is finished.");
            return response;
        }

        public async Task<BlockDeleteResponse[]?> DeleteAllBlocks(BlockDeleteAllRequest request) {
            _logger.LogDebug($"{nameof(DeleteAllBlocks)} in {nameof(UserBlockDbService)} is started.");

            _logger.LogInformation($"{nameof(_repo.DeleteAllBlocks)} in {nameof(IUserBlockRepository)} is starting.");
            UserBlockEntity[]? entities = await _repo.DeleteAllBlocks(request.UserId);

            if (entities is null) {
                _logger.LogError($"There is no entities that matches with conditions in {nameof(DeleteAllBlocks)}, returning null.");
                return null;
            }

            BlockDeleteResponse[] responses = await _converter.ToResponseAsync(entities, e => {
                return e.ToDeleteResponse();
            });

            _logger.LogInformation($"{nameof(DeleteAllBlocks)} in {nameof(UserBlockDbService)} is finished with {entities.Length} deletions.");
            return responses;
        }

        public async Task<BlockDeleteResponse?> DeleteBlock(BlockDeleteRequest request) {
            _logger.LogDebug($"{nameof(DeleteBlock)} in {nameof(UserBlockDbService)} is started.");

            _logger.LogInformation($"{nameof(_repo.DeleteBlock)} in {nameof(IUserBlockRepository)} is starting.");
            UserBlockEntity? entity = await _repo.DeleteBlock(request.UserId, request.BlockedUserId);

            if (entity is null) {
                _logger.LogError($"There is no entity that matches with conditions in {nameof(DeleteBlock)}, returning null.");
                return null;
            }

            BlockDeleteResponse response = entity.ToDeleteResponse();

            _logger.LogInformation($"{nameof(DeleteBlock)} in {nameof(UserBlockDbService)} is finished.");
            return response;
        }
        public async Task<BlockGetResponse[]?> GetBlocks(BlockGetAllRequest request) {
            _logger.LogDebug($"{nameof(GetBlocks)} in {nameof(UserBlockDbService)} is started.");

            _logger.LogInformation($"{nameof(_repo.GetAllBlocksByUserId)} in {nameof(IUserBlockRepository)} is starting.");
            UserBlockEntity[]? entities = await _repo.GetAllBlocksByUserId(request.UserId);

            if (entities is null) {
                _logger.LogError($"No Block Entities found with given parameters in {nameof(GetBlocks)}, returning null.");
                return null;
            }

            BlockGetResponse[]? responses = await _converter.ToResponseAsync(entities, e => {
                return e.ToGetResponse();
            });

            _logger.LogInformation($"{nameof(GetBlocks)} in {nameof(UserBlockDbService)} is finished with {entities.Length} blocks entities.");
            return responses;
        }

        public async Task<BlockGetResponse?> GetBlock(BlockGetRequest request) {
            _logger.LogDebug($"{nameof(GetBlock)} in {nameof(UserBlockDbService)} is started.");

            _logger.LogInformation($"{nameof(_repo.GetBlock)} in {nameof(IUserBlockRepository)} is starting.");
            UserBlockEntity? entity = await _repo.GetBlock(request.UserId, request.BlockedUserId);

            if (entity is null) {
                _logger.LogError($"No Block Entity found with given parameters, returning null.");
                return null;
            }

            BlockGetResponse? response = entity.ToGetResponse();

            _logger.LogInformation($"{nameof(GetBlock)} in {nameof(UserBlockDbService)} is finished.");
            return response;
        }

        public async Task<BlockGetResponse?> GetAmIBlocked(BlockGetRequest request) {
            _logger.LogDebug($"{nameof(GetAmIBlocked)} in {nameof(UserBlockDbService)} is started.");

            _logger.LogInformation($"{nameof(_repo.GetBlock)} in {nameof(IUserBlockRepository)} is starting.");
            UserBlockEntity? entity = await _repo.GetBlock(request.BlockedUserId, request.UserId);

            if (entity is null) {
                _logger.LogError($"No Block Entity found with given parameters, returning null.");
                return null;
            }

            BlockGetResponse? response = entity.ToGetResponse();

            _logger.LogInformation($"{nameof(GetAmIBlocked)} in {nameof(UserBlockDbService)} is finished.");
            return response;
        }
    }
}
