using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Repository.Report;
using RosanicSocial.Domain.Data.Entities.Report;
using RosanicSocial.Domain.DTO.Request.Reports.Ban;
using RosanicSocial.Domain.DTO.Response.Reports.Ban;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class UserBanDbService : IUserBanDbService {
        private readonly IUserBanRepository _repo;
        private readonly ILogger<UserBanDbService> _logger;
        public UserBanDbService(IUserBanRepository repository, ILogger<UserBanDbService> logger) {
            _repo = repository;
            _logger = logger;
        }
        public async Task<BanAddResponse> AddBan(BanAddRequest request) {
            _logger.LogInformation("Creating and Adding Ban Process is Started");

            UserBanEntity entity =  request.ToEntity();
            entity = await _repo.AddBan(entity);

            return null;
        }

        public Task<BanDeleteResponse> DeleteBan(BanDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<BanGetResponse> GetBan(BanGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<BanGetResponse[]> GetBansAllByUserId(BanGetAllByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<BanUpdateResponse> UpdateBan(BanUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
