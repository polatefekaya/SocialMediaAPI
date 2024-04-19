using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.Repository {
    public interface ILikeRepository {
        #region Comment

        Task<CommentLikesEntity> AddCommentLike(CommentLikesEntity commentLikesEntity);
        Task<CommentLikesEntity> GetCommentLike(int id);
        Task<IEnumerable<CommentLikesEntity>> GetAllCommentLikes(int id);
        Task<CommentLikesEntity> DeleteCommentLike(int id);
        Task<CommentLikesEntity> DeleteAllCommentLikes(int id);

        #endregion

        #region Post

        Task<PostLikesEntity> AddPostLike(PostLikesEntity commentLikesEntity);
        Task<PostLikesEntity> GetPostLike(int id);
        Task<IEnumerable<PostLikesEntity>> GetAllPostLikes(int id);
        Task<PostLikesEntity> DeletePostLike(int id);
        Task<PostLikesEntity> DeleteAllPostLikes(int id);

        #endregion
    }
}
