using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository {
    public interface ICommentRepository {
        Task<CommentEntity> AddComment(CommentEntity comment);
        Task<CommentEntity> GetComment(int id);
        Task<IEnumerable<CommentEntity>> GetAllComments(int id);
        Task<CommentEntity> UpdateComment(CommentEntity comment);
        Task<CommentEntity> DeleteComment(int id);
        Task<CommentEntity> DeleteAllComments(int id);
    }
}
