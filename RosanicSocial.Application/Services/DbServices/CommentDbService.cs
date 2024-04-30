using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CommentDbService> _logger;
        public CommentDbService(ICommentRepository commentRepository, ILogger<CommentDbService> logger) {
            _repo = commentRepository;
            _logger = logger;
        }

        public async Task<CommentAddResponse> AddCommentAsync(CommentAddRequest request) {
            _logger.LogInformation("Add Comment In Db Service is Started");

            CommentEntity commentEntity = request.ToEntity();
            commentEntity = await _repo.AddComment(commentEntity);
            return commentEntity.ToAddResponse();
        }

        public Task<CommentDeleteResponse> DeleteCommentAsync(CommentDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentGetResponse[]> GetAllCommentsByPostIdAsync(CommentGetAllByPostIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentGetResponse[]> GetAllCommentsByUserIdAsync(CommentGetAllByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentGetResponse> GetCommentAsync(CommentGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentUpdateResponse> UpdateCommentAsync(CommentUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
