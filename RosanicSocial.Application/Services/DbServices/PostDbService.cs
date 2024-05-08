using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Post;

namespace RosanicSocial.Application.Services.DbServices
{
    public class PostDbService : IPostDbService {
        private readonly IPostRepository _postRepository;
        public PostDbService(IPostRepository postRepository) {
            _postRepository = postRepository;
        }
        public async Task<PostAddResponse> AddPost(PostAddRequest request) {
            PostEntity entity = request.ToEntity();
            DateTime initTime = DateTime.UtcNow;

            entity.UpdatedAt = initTime;
            entity.CreatedAt = initTime;

            entity = await _postRepository.AddPost(entity);
            PostAddResponse response = entity.ToAddResponse();
            return response;
        }

        public Task<PostDeleteResponse[]> DeleteAllPosts(PostDeleteAllRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostDeleteResponse[]> DeleteBatchPost(PostDeleteBatchRequest request) {
            throw new NotImplementedException();
        }

        public async Task<PostDeleteResponse> DeletePost(PostDeleteRequest request) {
            PostEntity entity = await _postRepository.DeletePost(request.PostId);
            return entity.ToDeleteResponse();
        }

        public async Task<PostGetResponse[]> GetAllPostsById(PostGetAllRequest request) {
            PostEntity[] entities = await _postRepository.GetPostsByUserId(request.UserId);
            PostGetResponse[] responses = new PostGetResponse[entities.Length];
            for (int i = 0; i < entities.Length; i++) {
                responses[i] = entities[i].ToGetResponse();
            }
            return responses;
        }

        public async Task<PostGetResponse[]> GetByCategoryPost(PostGetByCategoryRequest request) {
            PostEntity[] entities = await _postRepository.GetPostsByUserId(request.UserId);
            PostEntity[] categorizedEntities = entities.Where(p => p.Category == request.Category).ToArray();

            PostGetResponse[] responses = new PostGetResponse[categorizedEntities.Length];
            for (int i = 0; i < categorizedEntities.Length; i++) {
                responses[i] = categorizedEntities[i].ToGetResponse();
            }
            return responses;
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
