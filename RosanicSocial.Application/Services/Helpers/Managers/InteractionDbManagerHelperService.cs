using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Helpers.Managers;
using RosanicSocial.Application.Services.DbServices;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.Helpers.Managers {
    public class InteractionDbManagerHelperService : IInteractionDbManagerHelperService {
        private readonly ILogger<InteractionDbManagerHelperService> _logger;
        private readonly IPostDbService _postDbService;
        public InteractionDbManagerHelperService(IPostDbService postDbService, ILogger<InteractionDbManagerHelperService> logger) {
            _logger = logger;
            _postDbService = postDbService;
        }

        public async Task<PostUpdateResponse?> UpdatePost(int postId, int change) {
            PostUpdateLikeCountRequest updateRequest = new PostUpdateLikeCountRequest {
                PostId = postId,
                Change = change
            };
            _logger.LogTrace($"{nameof(PostUpdateLikeCountRequest)} has PostId: {updateRequest.PostId}, Change: {updateRequest.Change}");

            PostUpdateResponse? postResponse = await _postDbService.UpdatePostLikeCount(updateRequest);
            _logger.LogDebug($"{nameof(_postDbService.UpdatePostLikeCount)} with {nameof(PostDbService)} is finished, (1/2)");
            if (postResponse == null) {
                _logger.LogWarning($"{nameof(PostUpdateResponse)} is null, returning null value may cause problems");
                return null;
            }

            _logger.LogTrace($"{nameof(PostUpdateResponse)} Object has UserId: {postResponse.UserId}, PostId: {postResponse.Id}, LikeCount: {postResponse.LikeCount}");
            return postResponse;
        }
    }
}
