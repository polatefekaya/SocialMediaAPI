using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Managers;
using RosanicSocial.Domain.DTO.Request.Comment;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Comment;
using RosanicSocial.Domain.DTO.Response.Info.Base;
using RosanicSocial.Domain.DTO.Response.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.Managers {
    public class SharingsDbManagerService : ISharingsDbManagerService {
        private readonly IUserInfoDbService _infoDb;
        private readonly IPostDbService _postDb;
        private readonly ICommentDbService _commentDb;
        public SharingsDbManagerService(ICommentDbService commentDb, IUserInfoDbService infoDb, IPostDbService postDb) {
            _infoDb = infoDb;
            _postDb = postDb;
            _commentDb = commentDb;
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

        public async Task<CommentAddResponse?> AddComment(CommentAddRequest request) {
            PostUpdateResponse? postResponse =  await _postDb.UpdatePostCommentCount(
                new PostUpdateCommentCountRequest {
                    PostId = request.PostId,
                    Change = 1
                });
            if (postResponse == null) { return null; }

            CommentAddResponse commentResposne = await _commentDb.AddCommentAsync(request);
            return commentResposne;
        }

        public async Task<CommentDeleteResponse?> DeleteComment(CommentDeleteRequest request) {
            PostUpdateResponse? postResponse = await _postDb.UpdatePostCommentCount(
                new PostUpdateCommentCountRequest {
                    PostId = request.PostId,
                    Change = 1
                });
            if (postResponse == null) { return null; }

            CommentDeleteResponse commentResponse = await _commentDb.DeleteCommentAsync(request);
            return commentResponse;
        }
    }
}
