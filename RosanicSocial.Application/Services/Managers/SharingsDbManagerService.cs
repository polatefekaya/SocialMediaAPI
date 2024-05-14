using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Managers;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Info.Base;
using RosanicSocial.Domain.DTO.Response.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.Managers {
    public class SharingsDbManagerService : ISharingsDbManagerService {
        private readonly IUserInfoDbService _infoDb;
        private readonly IPostDbService _postDb;
        public SharingsDbManagerService(IUserInfoDbService infoDb, IPostDbService postDb) {
            _infoDb = infoDb;
            _postDb = postDb;
        }
        public async Task<PostAddResponse?> AddPost(PostAddRequest request) {
            BaseInfoUpdateResponse? infoResponse = await _infoDb.UpdateBaseInfoPostCount(
                new BaseInfoUpdatePostCountRequest { 
                    UserId = request.UserId, 
                    Change = 1
                });
            if (infoResponse == null) { return null; }

            PostAddResponse postResponse = await _postDb.AddPost(request);

            return postResponse;
        }

        public Task<PostDeleteResponse?[]> DeleteAllPosts(PostDeleteAllRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostDeleteResponse?[]> DeleteBatchPost(PostDeleteBatchRequest request) {
            throw new NotImplementedException();
        }

        public async Task<PostDeleteResponse?> DeletePost(PostDeleteRequest request) {
            BaseInfoUpdateResponse? infoResponse = await _infoDb.UpdateBaseInfoPostCount(
                new BaseInfoUpdatePostCountRequest {
                    UserId = request.UserId,
                    Change = -1
                });
            if (infoResponse == null) { return null; }

            PostDeleteResponse postResponse = await _postDb.DeletePost(request);
            return postResponse;
        }
    }
}
