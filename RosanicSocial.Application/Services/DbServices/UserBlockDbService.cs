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
            _logger.LogDebug($"{nameof(AddBlock)} in {nameof(UserBlockDbService)} is started");
            UserBlockEntity? entity = request.ToEntity();

            _logger.LogInformation($"{nameof(_repo.AddBlock)} in {nameof(IUserBlockRepository)} is starting");
            entity = await _repo.AddBlock(entity);

            BlockAddResponse response = entity.ToAddResponse();

            _logger.LogInformation($"{nameof(AddBlock)} in {nameof(UserBlockDbService)} is finished");
            return response;
        }

        public async Task<BlockDeleteResponse[]> DeleteAllBlocks(BlockDeleteAllRequest request) {
            _logger.LogDebug($"{nameof(DeleteAllBlocks)} in {nameof(UserBlockDbService)} is started");

            _logger.LogInformation($"{nameof(_repo.DeleteAllBlocks)} in {nameof(IUserBlockRepository)} is starting");
            UserBlockEntity[] entities = await _repo.DeleteAllBlocks(request.UserId);

            BlockDeleteResponse[] responses = await _converter.ToResponseAsync(entities, e => {
                return e.ToDeleteResponse();
            });

            _logger.LogInformation($"{nameof(DeleteAllBlocks)} in {nameof(UserBlockDbService)} is finished with {entities.Length} deletions");
            return responses;
        }

        public async Task<BlockDeleteResponse?> DeleteBlock(BlockDeleteRequest request) {
            _logger.LogDebug($"{nameof(DeleteBlock)} in {nameof(UserBlockDbService)} is started");

            _logger.LogInformation($"{nameof(_repo.DeleteBlock)} in {nameof(IUserBlockRepository)} is starting");
            UserBlockEntity? entity = await _repo.DeleteBlock(request.UserId, request.BlockedUserId);
            if (entity == null) {
                _logger.LogError($"There is no entity that matches with conditions to delete, returning null.");
                return null;
            }

            BlockDeleteResponse response = entity.ToDeleteResponse();

            _logger.LogInformation($"{nameof(DeleteBlock)} in {nameof(UserBlockDbService)} is finished.");
            return response;
        }
        public Task<BlockGetResponse[]> GetBlocks(BlockGetAllRequest request) {
            throw new NotImplementedException();
        }

        public Task<BlockGetResponse?> GetBlock(BlockGetRequest request) {
            throw new NotImplementedException();
        }

    }
}
