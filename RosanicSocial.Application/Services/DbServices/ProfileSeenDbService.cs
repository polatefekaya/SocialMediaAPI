using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Seen.Profile;
using RosanicSocial.Domain.DTO.Response.Seen.Profile;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class ProfileSeenDbService : IProfileSeenDbService {
        public Task<ProfileSeenAddResponse> AddProfileSeen(ProfileSeenAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<ProfileSeenDeleteResponse[]> DeleteAllProfileSeenByUserId(ProfileSeenDeleteAllByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<ProfileSeenGetResponse> GetAllProfileSeenByUserId(ProfileSeenGetAllByUserIdRequest request) {
            throw new NotImplementedException();
        }
    }
}
