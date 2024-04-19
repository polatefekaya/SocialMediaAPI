using RosanicSocial.Application.Interfaces.Repository;
using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Infrastructure.Repository {
    public class CommentRepository : ICommentRepository {
        public Task<CommentEntity> AddComment(CommentEntity comment) {
            throw new NotImplementedException();
        }

        public Task<CommentEntity> DeleteAllComments(int id) {
            throw new NotImplementedException();
        }

        public Task<CommentEntity> DeleteComment(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommentEntity>> GetAllComments(int id) {
            throw new NotImplementedException();
        }

        public Task<CommentEntity> GetComment(int id) {
            throw new NotImplementedException();
        }

        public Task<CommentEntity> UpdateComment(CommentEntity comment) {
            throw new NotImplementedException();
        }
    }
}
