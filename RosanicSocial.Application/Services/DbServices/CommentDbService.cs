using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Comment;
using RosanicSocial.Domain.DTO.Response.Comment;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class CommentDbService : ICommentDbService {
        public Task<CommentAddResponse> AddCommentAsync(CommentAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentDeleteResponse> DeleteCommentAsync(CommentDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentGetAllResponse> GetAllCommentsAsync(CommentGetAllRequest request) {
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
