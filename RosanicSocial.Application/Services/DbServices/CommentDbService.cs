using Microsoft.Extensions.Logging;
using RosanicSocial.Application.Interfaces;
using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Application.Interfaces.Repository.Post;
using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Domain.DTO.Request.Comment;
using RosanicSocial.Domain.DTO.Response.Comment;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class CommentDbService : ICommentDbService {
        private readonly ICommentRepository _repo;
        private readonly IEntityConvertService _converter;
        private readonly ILogger<CommentDbService> _logger;
        public CommentDbService(ICommentRepository commentRepository, ILogger<CommentDbService> logger, IEntityConvertService converter) {
            _repo = commentRepository;
            _logger = logger;
            _converter = converter;
        }

        public async Task<CommentAddResponse> AddCommentAsync(CommentAddRequest request) {
            _logger.LogInformation("Add Comment in DbService is started");

            CommentEntity entity = request.ToEntity();

            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = entity.CreatedAt;

            entity = await _repo.AddComment(entity);
            return entity.ToAddResponse();
        }

        public async Task<CommentDeleteResponse[]> DeleteAllCommentsByUserIdAsync(CommentDeleteAllByUserIdRequest request) {
            _logger.LogInformation("Delete All Comments By User Id in DbService is started");

            CommentEntity[] entities = await _repo.DeleteAllComments(request.UserId);

            CommentDeleteResponse[] responses = await _converter.ToResponseAsync(entities, (c) => {
                return c.ToDeleteResponse();
            });

            return responses;
        }

        public async Task<CommentDeleteResponse> DeleteCommentAsync(CommentDeleteRequest request) {
            _logger.LogInformation("Delete Comment in DbService is started");
            
            CommentEntity? entity = await _repo.DeleteComment(request.CommentId);
            if (entity == null) { return null; }

            return entity.ToDeleteResponse();
        }

        public async Task<CommentGetResponse[]> GetAllCommentsByPostIdAsync(CommentGetAllByPostIdRequest request) {
            _logger.LogInformation("Get All Comments By Post Id in DbService is started");

            CommentEntity[] entities = await _repo.GetAllCommentsByPostId(request.PostId);

            CommentGetResponse[] responses = await _converter.ToResponseAsync(entities, (c) => {
                return c.ToGetResponse();
            });
            return responses;
        }

        public async Task<CommentGetResponse[]> GetAllCommentsByUserIdAsync(CommentGetAllByUserIdRequest request) {
            _logger.LogInformation("Get All Comments By User Id in DbService is started");

            CommentEntity[] entities = await _repo.GetAllCommentsByUserId(request.UserId);

            CommentGetResponse[] responses = await _converter.ToResponseAsync(entities, (c) => {
                return c.ToGetResponse();
            });
            return responses;
        }

        public async Task<CommentGetResponse> GetCommentAsync(CommentGetRequest request) {
            _logger.LogInformation("Get Comment in DbService is started");

            CommentEntity entity = await _repo.GetComment(request.CommentId);
            return entity.ToGetResponse();
        }

        public async Task<CommentUpdateResponse?> UpdateCommentAsync(CommentUpdateRequest request) {
            _logger.LogInformation("Update Comment in DbService is started");

            CommentEntity entity = request.ToEntity();

            entity.UpdatedAt = DateTime.UtcNow;
            entity.IsUpdated = true;

            return await baseUpdater(entity);
        }

        public async Task<CommentUpdateResponse?> UpdateCommentLikeCount(CommentUpdateLikeCountRequest request) {
            _logger.LogInformation("Update Comment Like Count in DbService is started");

            CommentEntity entity = await _repo.GetComment(request.CommentId);
            if (entity == null) { return null; }

            entity.LikeCount += request.Change;
            entity.UpdatedAt = DateTime.UtcNow;

            return await baseUpdater(entity);
        }
        public async Task<CommentUpdateResponse?> UpdateCommentCommentCount(CommentUpdateCommentCountRequest request) {
            _logger.LogInformation("Update Comment Comment Count in DbService is started");

            CommentEntity entity = await _repo.GetComment(request.CommentId);
            if (entity == null) { return null; }

            entity.CommentCount += request.Change;
            entity.UpdatedAt = DateTime.UtcNow;

            return await baseUpdater(entity);
        }

        private async Task<CommentUpdateResponse?> baseUpdater(CommentEntity entity) {
            CommentEntity? updatedEntity = await _repo.UpdateComment(entity);
            if (updatedEntity == null) { return null; }

            CommentUpdateResponse? response = updatedEntity.ToUpdateResponse();
            return response;
        }
    }
}
