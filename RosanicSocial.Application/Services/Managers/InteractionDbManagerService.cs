using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Managers;
using RosanicSocial.Domain.DTO.Request.Comment;
using RosanicSocial.Domain.DTO.Request.Likes.Comment;
using RosanicSocial.Domain.DTO.Request.Likes.Post;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Comment;
using RosanicSocial.Domain.DTO.Response.Likes.Comment;
using RosanicSocial.Domain.DTO.Response.Likes.Post;
using RosanicSocial.Domain.DTO.Response.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.Managers {
    public class InteractionDbManagerService : IInteractionDbManagerService {
        private readonly IPostDbService _postDbService;
        private readonly ILikeDbService _likeDbService;
        private readonly ICommentDbService _commentDbService;

        public InteractionDbManagerService(IPostDbService postDbService, ILikeDbService likeDbService, ICommentDbService commentDbService) {
            _postDbService = postDbService;
            _likeDbService = likeDbService;
            _commentDbService = commentDbService;
        }

        public async Task<PostLikesAddResponse?> AddPostLike(PostLikesAddRequest request) {
            PostUpdateResponse? postResponse = await _postDbService.UpdatePostLikeCount(
                new PostUpdateLikeCountRequest {
                    PostId = request.PostId,
                    Change = 1
                });
            if (postResponse == null) { return null; }

            PostLikesAddResponse likesResponse = await _likeDbService.AddPostLike(request);
            return likesResponse;
        }

        public async Task<PostLikesDeleteResponse?> DeletePostLike(PostLikesDeleteRequest request) {
            PostUpdateResponse? postResponse = await _postDbService.UpdatePostLikeCount(
                new PostUpdateLikeCountRequest {
                    PostId = request.PostId,
                    Change = -1
                });
            if (postResponse == null) { return null; }

            PostLikesDeleteResponse? likesResponse = await _likeDbService.DeletePostLike(request);
            return likesResponse;
        }

        public async Task<CommentLikesAddResponse?> AddCommentLike(CommentLikesAddRequest request) {
            CommentUpdateResponse? commentResponse = await _commentDbService.UpdateCommentLikeCount(
                new CommentUpdateLikeCountRequest {
                    CommentId = request.CommentId,
                    Change = 1
                });

            CommentLikesAddResponse? likesResponse = await _likeDbService.AddCommentLike(request);
            return likesResponse;
        }

        public async Task<CommentLikesDeleteResponse?> DeleteCommentLike(CommentLikesDeleteRequest request) {
            CommentUpdateResponse? commentResponse = await _commentDbService.UpdateCommentLikeCount(
                new CommentUpdateLikeCountRequest {
                    CommentId = request.CommentId,
                    Change = 1
                });

            CommentLikesDeleteResponse? likesResponse = await _likeDbService.DeleteCommentLike(request);
            return likesResponse;
        }
    }
}
