using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Likes.Comment;
using RosanicSocial.Domain.DTO.Request.Likes.Post;
using RosanicSocial.Domain.DTO.Response.Likes.Comment;
using RosanicSocial.Domain.DTO.Response.Likes.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class LikeDbService : ILikeDbService {
        public Task<CommentLikesAddResponse> AddCommentLike(CommentLikesAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostLikesAddResponse> AddPostLike(PostLikesAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentLikesDeleteResponse[]> DeleteAllCommentLikes(int id) {
            throw new NotImplementedException();
        }

        public Task<PostLikesDeleteResponse[]> DeleteAllPostLikes(int id) {
            throw new NotImplementedException();
        }

        public Task<CommentLikesDeleteResponse> DeleteCommentLike(CommentLikesDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostLikesDeleteResponse> DeletePostLike(PostLikesDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentLikesGetResponse[]> GetCommentLikes(CommentLikesGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<CommentLikesGetResponse[]> GetCommentLikesByUserId(CommentLikesByUserIdGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostLikesGetResponse[]> GetPostLikes(PostLikesGetRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostLikesGetResponse[]> GetPostLikesByUserId(PostLikesByUserIdGetRequest request) {
            throw new NotImplementedException();
        }
    }
}
