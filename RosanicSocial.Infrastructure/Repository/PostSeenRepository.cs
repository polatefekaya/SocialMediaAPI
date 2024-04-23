using RosanicSocial.Application.Interfaces.Repository.Statistic;
using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class PostSeenRepository : IPostSeenRepository {
        public Task<PostSeenEntity> AddPostSeen(PostSeenEntity entity) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PostSeenEntity>> DeletePostSeensByPostId(int postId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PostSeenEntity>> DeletePostSeensByUserId(int userId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PostSeenEntity>> GetPostSeensByPostId(int postId) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PostSeenEntity>> GetPostSeensByUserId(int userId) {
            throw new NotImplementedException();
        }
    }
}
