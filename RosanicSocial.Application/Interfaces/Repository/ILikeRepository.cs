using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository {
    public interface ILikeRepository {
        #region Comment

        Task<CommentLikesEntity?> AddCommentLike(CommentLikesEntity commentLikesEntity);
        Task<CommentLikesEntity?> GetCommentLike(int commentId, int userId);
        Task<CommentLikesEntity[]> GetAllCommentLikesByUserId(int id);
        Task<CommentLikesEntity[]> GetAllCommentLikesByCommentId(int id);
        Task<CommentLikesEntity?> DeleteCommentLike(int commentId, int userId);
        Task<CommentLikesEntity[]> DeleteAllCommentLikesByUserId(int id);
        Task<CommentLikesEntity[]> DeleteAllCommentLikesByCommentId(int id);

        #endregion

        #region Post

        Task<PostLikesEntity?> AddPostLike(PostLikesEntity commentLikesEntity);
        Task<PostLikesEntity?> GetPostLike(int postId, int userId);
        Task<PostLikesEntity[]> GetAllPostLikesByUserId(int id);
        Task<PostLikesEntity[]> GetAllPostLikesByPostId(int id);
        Task<PostLikesEntity?> DeletePostLike(int postId, int userId);
        Task<PostLikesEntity[]> DeleteAllPostLikesByUserId(int id);
        Task<PostLikesEntity[]> DeleteAllPostLikesByPostId(int id);

        #endregion
    }
}
