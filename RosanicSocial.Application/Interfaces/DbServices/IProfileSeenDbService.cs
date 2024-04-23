using RosanicSocial.Domain.DTO.Request.Seen.Profile;
using RosanicSocial.Domain.DTO.Response.Seen.Profile;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IProfileSeenDbService {
        Task<ProfileSeenAddResponse> AddProfileSeen(ProfileSeenAddRequest request);
        Task<ProfileSeenGetAllByUserIdResponse> GetAllProfileSeenByUserId(ProfileSeenGetAllByUserIdRequest request);
        Task<ProfileSeenDeleteAllByUserIdResponse> DeleteAllProfileSeenByUserId(ProfileSeenDeleteAllByUserIdRequest request);
    }
}
