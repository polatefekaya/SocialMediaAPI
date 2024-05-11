using RosanicSocial.Application.Interfaces;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Domain.DTO.Request.Likes.Comment;
using RosanicSocial.Domain.DTO.Request.Likes.Post;
using RosanicSocial.Domain.DTO.Response.Likes.Comment;
using RosanicSocial.Domain.DTO.Response.Likes.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class LikeDbService : ILikeDbService {
        private readonly ILikeRepository _repo;
        private readonly IEntityConvertService _converter;
        public LikeDbService(ILikeRepository repo, IEntityConvertService converter) {
            _repo = repo;
            _converter = converter;
        }
        public async Task<CommentLikesAddResponse> AddCommentLike(CommentLikesAddRequest request) {
            CommentLikesEntity entity = request.ToEntity();
            entity.CreatedAt = DateTime.UtcNow;
            entity = await _repo.AddCommentLike(entity);
            return entity.ToAddResponse();
        }

        public async Task<PostLikesAddResponse> AddPostLike(PostLikesAddRequest request) {
            PostLikesEntity entity = request.ToEntity();
            entity.CreatedAt = DateTime.UtcNow;
            entity = await _repo.AddPostLike(entity);
            return entity.ToAddResponse();
        }

        #region DELETE
        #region Comment
        public async Task<CommentLikesDeleteResponse[]> DeleteAllCommentLikesByUserId(CommentLikesDeleteAllByUserIdRequest request) {
            CommentLikesEntity[] entities = await _repo.DeleteAllCommentLikesByUserId(request.UserId);

            CommentLikesDeleteResponse[] responses = await _converter.ToResponseAsync(entities, e => {
                return e.ToDeleteResponse();
            });
            return responses;
        }

        public async Task<CommentLikesDeleteResponse[]> DeleteAllCommentLikesCommentId(CommentLikesDeleteAllByCommentIdRequest request) {
            CommentLikesEntity[] entities = await _repo.DeleteAllCommentLikesByCommentId(request.CommentId);

            CommentLikesDeleteResponse[] responses = await _converter.ToResponseAsync(entities, e => {
                return e.ToDeleteResponse();
            });
            return responses;
        }
        public async Task<CommentLikesDeleteResponse?> DeleteCommentLike(CommentLikesDeleteRequest request) {
            CommentLikesEntity? entity = await _repo.DeleteCommentLike(request.CommentId, request.UserId);
            if (entity == null) { return null; }
            CommentLikesDeleteResponse response = entity.ToDeleteResponse();
            return response;
        }
        #endregion

        #region Post
        public async Task<PostLikesDeleteResponse[]> DeleteAllPostLikesByPostId(PostLikesDeleteAllByPostIdRequest request) {
            PostLikesEntity[] entities = await _repo.DeleteAllPostLikesByPostId(request.PostId);
            PostLikesDeleteResponse[] responses = await _converter.ToResponseAsync(entities, pl => {
                return pl.ToDeleteResponse();
            });
            return responses;
        }

        public async Task<PostLikesDeleteResponse[]> DeleteAllPostLikesByUserId(PostLikesDeleteAllByUserIdRequest request) {
            PostLikesEntity[] entities = await _repo.DeleteAllPostLikesByUserId(request.UserId);
            PostLikesDeleteResponse[] responses = await _converter.ToResponseAsync(entities, pl => {
                return pl.ToDeleteResponse();
            });
            return responses;
        }
        public async Task<PostLikesDeleteResponse?> DeletePostLike(PostLikesDeleteRequest request) {
            PostLikesEntity? entity = await _repo.DeletePostLike(request.PostId, request.UserId);
            if (entity == null) { return null; }
            PostLikesDeleteResponse response = entity.ToDeleteResponse();
            return response;

        }
        #endregion
        #endregion

        #region GET
        #region Comment
        public async Task<CommentLikesGetResponse[]> GetAllCommentLikesByCommentId(CommentLikesGetAllByCommentIdRequest request) {
            CommentLikesEntity[] entities = await _repo.GetAllCommentLikesByCommentId(request.CommentId);
            CommentLikesGetResponse[] responses = await _converter.ToResponseAsync(entities, cl => {
                return cl.ToGetResponse();
            });
            return responses;
        }
        public async Task<CommentLikesGetResponse[]> GetAllCommentLikesByUserId(CommentLikesGetAllByUserIdRequest request) {
            CommentLikesEntity[] entities = await _repo.GetAllCommentLikesByUserId(request.UserId);
            CommentLikesGetResponse[] responses = await _converter.ToResponseAsync(entities, cl => {
                return cl.ToGetResponse();
            });
            return responses;
        }
        public async Task<CommentLikesGetResponse?> GetCommentLike(CommentLikesGetRequest request) {
            CommentLikesEntity? entity = await _repo.GetCommentLike(request.CommentId, request.UserId);
            if (entity == null) { return null; }
            CommentLikesGetResponse response = entity.ToGetResponse();
            return response;
        }
        #endregion
        #region Post
        public async Task<PostLikesGetResponse[]> GetAllPostLikesByPostId(PostLikesGetAllByPostIdRequest request) {
            PostLikesEntity[] entities = await _repo.GetAllPostLikesByPostId(request.PostId);
            PostLikesGetResponse[] responses = await _converter.ToResponseAsync(entities, pl => {
                return pl.ToGetResponse();
            });
            return responses;
        }
        public async Task<PostLikesGetResponse[]> GetAllPostLikesByUserId(PostLikesGetAllByUserIdRequest request) {
            PostLikesEntity[] entities = await _repo.GetAllPostLikesByUserId(request.UserId);
            PostLikesGetResponse[] responses = await _converter.ToResponseAsync(entities, pl => {
                return pl.ToGetResponse();
            });
            return responses;
        }
        public async Task<PostLikesGetResponse?> GetPostLike(PostLikesGetRequest request) {
            PostLikesEntity? entity = await _repo.GetPostLike(request.PostId, request.UserId);
            if (entity == null) { return null;}
            PostLikesGetResponse response = entity.ToGetResponse();
            return response;
        }
        #endregion
        #endregion
    }
}
