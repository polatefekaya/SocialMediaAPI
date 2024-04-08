using System;
using System.Collections.Generic;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.DTO.Request.Rose;
using RosanicSocial.Domain.DTO.Response.Rose;
using RosanicSocial.Domain.Models;

namespace RosanicSocial.Application.Services {
    public class RoseDbService : IRoseDbService {

        private readonly IRoseRepository _roseRepository;

        public RoseDbService(IRoseRepository roseRepository) {
            _roseRepository = roseRepository;
        }

        public async Task<RoseAddResponse> AddRose(RoseAddRequest request) {
            RoseEntity rose = request.ToEntity();
            await _roseRepository.AddRose(rose);
            return rose.ToAddResponse();
        }

        public async Task<RoseDeleteResponse> DeleteRose(RoseDeleteRequest request) {
            RoseEntity rose = request.ToEntity();
            await _roseRepository.DeleteRose(rose);
            return rose.ToDeleteResponse();
        }

        public Task<RoseGetResponse> GetRose(RoseGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<RoseUpdateResponse> UpdateRose(RoseUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
