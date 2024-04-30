using System;
using System.Collections.Generic;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Post;

namespace RosanicSocial.Application.Services.DbServices
{
    public class PostDbService : IPostDbService {
        public Task<PostAddResponse> AddPost(PostAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostDeleteResponse[]> DeleteAllPosts(PostDeleteAllRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostDeleteResponse[]> DeleteBatchPost(PostDeleteBatchRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostDeleteResponse> DeletePost(PostDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostGetResponse[]> GetAllPosts(PostGetAllRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostGetResponse[]> GetByCategoryPost(PostGetByCategoryRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostGetResponse[]> GetByTopicPost(PostGetByTopicRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostGetResponse[]> GetByTypePost(PostGetByTypeRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostGetResponse[]> GetFollowingUsersPosts(PostGetFollowingsRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostGetResponse[]> GetInterestedPosts(PostGetInterestedRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostGetResponse> GetPost(PostGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostUpdateResponse> UpdatePost(PostUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
