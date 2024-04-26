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
        public CommentDbService(ICommentRepository commentRepository) {
            _repo = commentRepository;
        }
        public async Task<CommentAddResponse> AddCommentAsync(CommentAddRequest request) {
            CommentEntity entity = request.ToEntity();
            entity =  await _repo.AddComment(entity);
            CommentAddResponse response = entity.ToAddResponse();
            return response;
        }

        public async Task<CommentDeleteResponse> DeleteCommentAsync(CommentDeleteRequest request) {
            CommentEntity entity = request.ToEntity();
            entity = await _repo.DeleteComment(entity.Id);
            CommentDeleteResponse response = entity.ToDeleteResponse();
            return response;
        }

        public async Task<CommentGetAllByPostIdResponse> GetAllCommentsByPostIdAsync(CommentGetAllByPostIdRequest request) {
            throw new NotImplementedException();
        }

        public async Task<CommentGetAllByUserIdResponse> GetAllCommentsByUserIdAsync(CommentGetAllByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public async Task<CommentGetResponse> GetCommentAsync(CommentGetRequest request) {
            throw new NotImplementedException();
        }

        public async Task<CommentUpdateResponse> UpdateCommentAsync(CommentUpdateRequest request) {
            throw new NotImplementedException();
        }
    }
}
