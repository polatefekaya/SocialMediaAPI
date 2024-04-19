using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Follows;
using RosanicSocial.Domain.DTO.Response.Follows;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class FollowDbService : IFollowDbService {
        public Task<FollowsAddResponse> AddFollow(FollowsAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<FollowsDeleteResponse> DeleteFollow(FollowsDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<FollowsGetFollowersResponse> GetFollowers(FollowsGetFollowersRequest request) {
            throw new NotImplementedException();
        }

        public Task<FollowsGetFollowingsResponse> GetFollowings(FollowsGetFollowingsRequest request) {
            throw new NotImplementedException();
        }
    }
}
