using System;
using System.Collections.Generic;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Domain.DTO.Request.Rose;
using RosanicSocial.Domain.DTO.Response.Rose;
using RosanicSocial.Domain.Models;

namespace RosanicSocial.Application.Services {
    public class RoseDbService : IRoseDbService {
        public async Task<RoseAddResponse> AddRose(RoseAddRequest request) {
            RoseEntity rose = request.ToEntity();
            return rose.ToAddResponse();
        }

        public Task<RoseDeleteResponse> DeleteRose(RoseDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<RoseGetResponse> GetRose(RoseGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<RoseUpdateResponse> UpdateRose(RoseUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
