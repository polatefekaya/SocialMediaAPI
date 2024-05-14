using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Post;

namespace RosanicSocial.Application.Services.DbServices
{
    public class PostDbService : IPostDbService {
        private readonly IPostRepository _postRepository;
        private readonly IEntityConvertService _converter;
        public PostDbService(IPostRepository postRepository, IEntityConvertService converter) {
            _postRepository = postRepository;
            _converter = converter;
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

        public async Task<PostDeleteResponse[]> DeleteAllPosts(PostDeleteAllRequest request) {
            PostEntity[] entities = await _postRepository.DeleteAllPostsByUserId(request.UserId);

            return await _converter.ToResponseAsync(entities, (e) => {
                return e.ToDeleteResponse();
            });
        }

        public async Task<PostDeleteResponse[]> DeleteBatchPost(PostDeleteBatchRequest request) {
            PostEntity[] entities = await _postRepository.DeleteBatchPost(request.PostIds);

            return await _converter.ToResponseAsync(entities, (e) => {
                return e.ToDeleteResponse();
            });
        }

        public async Task<PostDeleteResponse> DeletePost(PostDeleteRequest request) {
            PostEntity entity = await _postRepository.DeletePost(request.PostId);
            return entity.ToDeleteResponse();
        }

        public async Task<PostGetResponse[]> GetAllPostsById(PostGetAllRequest request) {
            PostEntity[] entities = await _postRepository.GetPostsByUserId(request.UserId);
            return await _converter.ToResponseAsync(entities, (e) => {
                return e.ToGetResponse();
            });
        }

        public async Task<PostGetResponse[]> GetByCategoryPost(PostGetByCategoryRequest request) {
            PostEntity[] entities = await _postRepository.GetPostsByUserId(request.UserId);
            PostEntity[] categorizedEntities = entities.Where(p => p.Category == request.Category).ToArray();

            return await _converter.ToResponseAsync(categorizedEntities, (e) => {
                return e.ToGetResponse();
            });
        }

        public async Task<PostGetResponse[]> GetByTopicPost(PostGetByTopicRequest request) {
            PostEntity[] entities = await _postRepository.GetPostsByUserId(request.UserId);
            PostEntity[] categorizedEntities = entities.Where(p =>
                    p.Category == request.Category && p.Type == request.Type && p.Topic == request.Topic
                ).ToArray();

            return await _converter.ToResponseAsync(categorizedEntities, (e) => {
                return e.ToGetResponse();
            });
        }

        public async Task<PostGetResponse[]> GetByTypePost(PostGetByTypeRequest request) {
            PostEntity[] entities = await _postRepository.GetPostsByUserId(request.UserId);
            PostEntity[] categorizedEntities = entities.Where(p =>
                    p.Category == request.Category && p.Type == request.Type
                ).ToArray();

            return await _converter.ToResponseAsync(categorizedEntities, (e) => {
                return e.ToGetResponse();
            });
        }

        public Task<PostGetResponse[]> GetFollowingUsersPosts(PostGetFollowingsRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostGetResponse[]> GetInterestedPosts(PostGetInterestedRequest request) {
            throw new NotImplementedException();
        }

        public async Task<PostGetResponse> GetPost(PostGetRequest request) {
            PostEntity? entity = await _postRepository.GetPostById(request.PostId);
            if(entity is null) { return null; }

            PostGetResponse response = entity.ToGetResponse();
            return response;
        }

        public async Task<PostUpdateResponse?> UpdatePost(PostUpdateRequest request) {
            PostEntity entity = request.ToEntity();
            entity.IsUpdated = true;
            entity.UpdatedAt = DateTime.UtcNow;

            return await baseUpdater(entity);
        }

        public async Task<PostUpdateResponse?> UpdatePostLikeCount(PostUpdateLikeCountRequest request) {
            PostEntity? entity = await _postRepository.GetPostById(request.PostId);
            if (entity == null) { return null; }

            entity.LikeCount += request.Change;
            entity.UpdatedAt = DateTime.UtcNow;

            return await baseUpdater(entity);
        }

        public async Task<PostUpdateResponse?> UpdatePostCommentCount(PostUpdateCommentCountRequest request) {
            PostEntity? entity = await _postRepository.GetPostById(request.PostId);
            if (entity == null) { return null; }

            entity.CommentCount += request.Change;
            entity.UpdatedAt = DateTime.UtcNow;

            return await baseUpdater(entity);
        }

        private async Task<PostUpdateResponse?> baseUpdater(PostEntity entity) {
            PostEntity? updatedEntity = await _postRepository.UpdatePost(entity);
            if (updatedEntity is null) { return null; }

            PostUpdateResponse response = updatedEntity.ToUpdateResponse();
            return response;
        }
    }
}

