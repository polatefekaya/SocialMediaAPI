using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Managers;
using RosanicSocial.Domain.DTO.Request.Comment;
using RosanicSocial.Domain.DTO.Request.Follows;
using RosanicSocial.Domain.DTO.Request.Info.Base;
using RosanicSocial.Domain.DTO.Request.Likes.Comment;
using RosanicSocial.Domain.DTO.Request.Likes.Post;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Comment;
using RosanicSocial.Domain.DTO.Response.Follows;
using RosanicSocial.Domain.DTO.Response.Info.Base;
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
        private readonly IUserInfoDbService _userInfoDbService;
        private readonly IFollowDbService _followDbService;

        private readonly ILogger<InteractionDbManagerService> _logger;

        public InteractionDbManagerService(ILogger<InteractionDbManagerService> logger, IFollowDbService followDbService, IUserInfoDbService userInfoDbService, IPostDbService postDbService, ILikeDbService likeDbService, ICommentDbService commentDbService) {
            _postDbService = postDbService;
            _likeDbService = likeDbService;
            _commentDbService = commentDbService;
            _userInfoDbService = userInfoDbService;
            _followDbService = followDbService;
            _logger = logger;
        }

        public async Task<PostLikesAddResponse?> AddPostLike(PostLikesAddRequest request) {
            _logger.LogInformation("AddPostLike in InteractionDbService is started");
            _logger.LogDebug("Total 2 DbService processes");

            PostUpdateLikeCountRequest updateRequest = new PostUpdateLikeCountRequest {
                PostId = request.PostId,
                Change = 1
            };
            _logger.LogTrace($"Update Like Count Request Object has PostId: {updateRequest.PostId}, Change: {updateRequest.Change}");

            PostUpdateResponse? postResponse = await _postDbService.UpdatePostLikeCount(updateRequest);
            _logger.LogDebug("UpdatePosLikeCount with PostDbService is finished, (1/2)");
            if (postResponse == null) {
                _logger.LogWarning("PostUpdateResponse is null, returning null value may cause problems");
                return null;
            }

            _logger.LogTrace($"PostUpdateResponse Object has UserId: {postResponse.UserId}, PostId: {postResponse.Id}, LikeCount: {postResponse.LikeCount}");


            PostLikesAddResponse? likesResponse = await _likeDbService.AddPostLike(request);
            _logger.LogDebug("AddPostLike with LikeDbService is finished. (2/2)");

            if (likesResponse == null) {
                _logger.LogWarning("PostLikesAddResponse is null, returning null value may cause problems");
            }
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

        public async Task<FollowsAddResponse?> AddFollow(FollowsAddRequest request) {
            BaseInfoUpdateResponse? infoFollowingResponse = await _userInfoDbService.UpdateBaseInfoFollowingCount(
                new BaseInfoUpdateFollowCountRequest {
                    UserId = request.UserId,
                    Change = 1
                });
            if (infoFollowingResponse == null) { return null; }

            BaseInfoUpdateResponse? infoFollowerResponse = await _userInfoDbService.UpdateBaseInfoFollowerCount(
                new BaseInfoUpdateFollowCountRequest {
                    UserId = request.FollowingId,
                    Change = 1
                });
            if (infoFollowerResponse == null) { return null;}

            FollowsAddResponse? followResponse = await _followDbService.AddFollow(request);
            return followResponse;
        }

        public async Task<FollowsDeleteResponse?> DeleteFollow(FollowsDeleteRequest request) {
            BaseInfoUpdateResponse? infoFollowingResponse = await _userInfoDbService.UpdateBaseInfoFollowingCount(
                new BaseInfoUpdateFollowCountRequest {
                    UserId = request.UserId,
                    Change = -1
                });
            if (infoFollowingResponse == null) { return null; }

            BaseInfoUpdateResponse? infoFollowerResponse = await _userInfoDbService.UpdateBaseInfoFollowerCount(
                new BaseInfoUpdateFollowCountRequest {
                    UserId = request.FollowingId,
                    Change = -1
                });
            if (infoFollowerResponse == null) { return null; }

            FollowsDeleteResponse? followsReponse = await _followDbService.DeleteFollow(request);
            return followsReponse;
        }
    }
}
