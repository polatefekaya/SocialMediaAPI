using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class LikeRepository : ILikeRepository {
        public Task<CommentLikesEntity> AddCommentLike(CommentLikesEntity commentLikesEntity) {
            throw new NotImplementedException();
        }

        public Task<PostLikesEntity> AddPostLike(PostLikesEntity commentLikesEntity) {
            throw new NotImplementedException();
        }

        public Task<CommentLikesEntity> DeleteAllCommentLikes(int id) {
            throw new NotImplementedException();
        }

        public Task<PostLikesEntity> DeleteAllPostLikes(int id) {
            throw new NotImplementedException();
        }

        public Task<CommentLikesEntity> DeleteCommentLike(int id) {
            throw new NotImplementedException();
        }

        public Task<PostLikesEntity> DeletePostLike(int id) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<CommentLikesEntity>> GetAllCommentLikes(int id) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PostLikesEntity>> GetAllPostLikes(int id) {
            throw new NotImplementedException();
        }

        public Task<CommentLikesEntity> GetCommentLike(int id) {
            throw new NotImplementedException();
        }

        public Task<PostLikesEntity> GetPostLike(int id) {
            throw new NotImplementedException();
        }
    }
}
