using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository.Post
{
    public interface ICommentRepository
    {
        Task<CommentEntity> AddComment(CommentEntity comment);
        Task<CommentEntity> GetComment(int id);
        Task<IQueryable<CommentEntity>> GetAllCommentsByUserId(int userId);
        Task<IQueryable<CommentEntity>> GetAllCommentsByPostId(int postId);
        Task<CommentEntity> UpdateComment(CommentEntity comment);
        Task<CommentEntity> DeleteComment(int id);
        Task<CommentEntity> DeleteAllComments(int id);
    }
}
