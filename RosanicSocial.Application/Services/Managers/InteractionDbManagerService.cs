using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Helpers.Managers;
using RosanicSocial.Application.Interfaces.Managers;
using RosanicSocial.Application.Services.DbServices;
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

        private readonly IInteractionDbManagerHelperService _helper;

        private readonly ILogger<InteractionDbManagerService> _logger;

        public InteractionDbManagerService(IInteractionDbManagerHelperService helper, ILogger<InteractionDbManagerService> logger, IFollowDbService followDbService, IUserInfoDbService userInfoDbService, IPostDbService postDbService, ILikeDbService likeDbService, ICommentDbService commentDbService) {
            _postDbService = postDbService;
            _likeDbService = likeDbService;
            _commentDbService = commentDbService;
            _userInfoDbService = userInfoDbService;
            _followDbService = followDbService;
            _logger = logger;
            _helper = helper;
        }

        public async Task<PostLikesAddResponse?> AddPostLike(PostLikesAddRequest request) {
            _logger.LogInformation($"{nameof(AddPostLike)} in {nameof(InteractionDbManagerService)} is started");
            _logger.LogDebug("Total of 2 DbService Processes");

            PostLikesAddResponse? likesResponse = await _likeDbService.AddPostLike(request);
            _logger.LogDebug($"{nameof(AddPostLike)} with {nameof(LikeDbService)} is finished. (2/2)");

            if (likesResponse is null) {
                _logger.LogError($"{nameof(PostLikesAddResponse)} is null, duplicate records can cause this issue.");
                return null;
            }

            //It will update the post entity to increment post like count on this post.
            PostUpdateResponse? updateResponse = await _helper.UpdatePost(request.PostId, 1);

            return likesResponse;
        }

        public async Task<PostLikesDeleteResponse?> DeletePostLike(PostLikesDeleteRequest request) {
            _logger.LogDebug($"{nameof(DeletePostLike)} in {nameof(InteractionDbManagerService)} is started");
            _logger.LogDebug("Total of 2 DbService Processes");

            PostUpdateResponse? updateResponse = await _helper.UpdatePost(request.PostId, -1);

            PostLikesDeleteResponse? likesResponse = await _likeDbService.DeletePostLike(request);
            _logger.LogDebug($"{nameof(DeletePostLike)} with {nameof(LikeDbService)} is finished. (2/2)");

            if (likesResponse is null) {
                _logger.LogError($"{nameof(PostLikesDeleteResponse)} is null, returning null value may cause problems");
            }
            return likesResponse;
        }

        private async Task<PostUpdateResponse?> basePostUpdate(int postId, int change) {
            PostUpdateLikeCountRequest updateRequest = new PostUpdateLikeCountRequest {
                PostId = postId,
                Change = change
            };
            _logger.LogTrace($"{nameof(PostUpdateLikeCountRequest)} has PostId: {updateRequest.PostId}, Change: {updateRequest.Change}");

            PostUpdateResponse? postResponse = await _postDbService.UpdatePostLikeCount(updateRequest);
            _logger.LogDebug($"{nameof(_postDbService.UpdatePostLikeCount)} with {nameof(PostDbService)} is finished, (1/2)");
            if (postResponse is null) {
                _logger.LogWarning($"{nameof(PostUpdateResponse)} is null, returning null value may cause problems");
                return null;
            }

            _logger.LogTrace($"{nameof(PostUpdateResponse)} Object has UserId: {postResponse.UserId}, PostId: {postResponse.Id}, LikeCount: {postResponse.LikeCount}");
            return postResponse;
        }

        public async Task<CommentLikesAddResponse?> AddCommentLike(CommentLikesAddRequest request) {
            _logger.LogDebug($"{nameof(AddCommentLike)} in {nameof(InteractionDbManagerService)} is started");

            CommentLikesAddResponse? likesResponse = await _likeDbService.AddCommentLike(request);
            if (likesResponse is null) {
                _logger.LogError($"{nameof(CommentLikesAddResponse)} is null, duplicate records can cause this issue.");
                return null;
            }

            CommentUpdateResponse? commentResponse = await _commentDbService.UpdateCommentLikeCount(
                new CommentUpdateLikeCountRequest {
                    CommentId = request.CommentId,
                    Change = 1
                });

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
            if (infoFollowingResponse is null) { return null; }

            BaseInfoUpdateResponse? infoFollowerResponse = await _userInfoDbService.UpdateBaseInfoFollowerCount(
                new BaseInfoUpdateFollowCountRequest {
                    UserId = request.FollowingId,
                    Change = 1
                });
            if (infoFollowerResponse is null) { return null;}

            FollowsAddResponse? followResponse = await _followDbService.AddFollow(request);
            return followResponse;
        }

        public async Task<FollowsDeleteResponse?> DeleteFollow(FollowsDeleteRequest request) {
            BaseInfoUpdateResponse? infoFollowingResponse = await _userInfoDbService.UpdateBaseInfoFollowingCount(
                new BaseInfoUpdateFollowCountRequest {
                    UserId = request.UserId,
                    Change = -1
                });
            if (infoFollowingResponse is null) { return null; }

            BaseInfoUpdateResponse? infoFollowerResponse = await _userInfoDbService.UpdateBaseInfoFollowerCount(
                new BaseInfoUpdateFollowCountRequest {
                    UserId = request.FollowingId,
                    Change = -1
                });
            if (infoFollowerResponse is null) { return null; }

            FollowsDeleteResponse? followsReponse = await _followDbService.DeleteFollow(request);
            return followsReponse;
        }
    }
}
