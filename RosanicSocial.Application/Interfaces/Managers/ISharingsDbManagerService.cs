using RosanicSocial.Domain.DTO.Request.Comment;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Comment;
using RosanicSocial.Domain.DTO.Response.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Managers {
    public interface ISharingsDbManagerService {
        public Task<PostAddResponse?> AddPost(PostAddRequest request);
        public Task<PostDeleteResponse?> DeletePost(PostDeleteRequest request);
        public Task<PostDeleteResponse?[]> DeleteAllPosts(PostDeleteAllRequest request);
        public Task<PostDeleteResponse?[]> DeleteBatchPost(PostDeleteBatchRequest request);
        Task<CommentAddResponse?> AddComment(CommentAddRequest request);
        Task<CommentDeleteResponse?> DeleteComment(CommentDeleteRequest request);
    }
}
