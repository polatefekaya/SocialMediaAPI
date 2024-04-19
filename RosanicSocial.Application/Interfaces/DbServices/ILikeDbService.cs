using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Domain.DTO.Request.Likes.Comment;
using RosanicSocial.Domain.DTO.Request.Likes.Post;
using RosanicSocial.Domain.DTO.Response.Likes.Comment;
using RosanicSocial.Domain.DTO.Response.Likes.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RosanicSocial.Application.Interfaces.DbServices {
    /// <summary>
    /// CRUD operations for Like Entity.
    /// <para>
    ///    CommentLike Functionality:
    /// </para>
    /// <list type="bullet">
    /// <item>Add</item>
    /// <item>Get</item>
    /// <item>Delete</item>
    /// <item>DeleteAll</item>
    /// </list>
    /// 
    /// <para>
    ///    PostLike Functionality:
    /// </para>
    /// <list type="bullet">
    /// <item>Add</item>
    /// <item>Get</item>
    /// <item>Delete</item>
    /// <item>DeleteAll</item>
    /// </list>
    /// This DbService calls Repository interfaces for it's db processes
    /// </summary>
    public interface ILikeDbService {
        #region Comment
        /// <summary>
        /// Adds the CommentLike Entity to database.
        /// <para>
        /// It needs to know who liked which comment. 
        /// </para>
        /// <para>
        /// Giving <paramref name="userId"/> and <paramref name="commentId"/> in <paramref name="request"/> is a must.
        /// </para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommentLikesAddResponse> AddCommentLike(CommentLikesAddRequest request);
        Task<IEnumerable<CommentLikesGetResponse>> GetCommentLikes(CommentLikesGetRequest request);
        Task<CommentLikesDeleteResponse> DeleteCommentLike(CommentLikesDeleteRequest request);
        Task<CommentLikesDeleteResponse> DeleteAllCommentLikes(int id);
        #endregion

        #region Post
        /// <summary>
        /// Adds the PostLike Entity to database.
        /// <para>
        /// It needs to know who liked which user's post. 
        /// </para>
        /// <para>
        /// Giving <paramref name="userId"/> and <paramref name="postId"/> in <paramref name="request"/> is a must.
        /// </para>
        /// <para>
        /// This given <paramref name="userId"/> is id of the User who liked the post.
        /// </para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PostLikesAddResponse> AddPostLike(PostLikesAddRequest request);
        Task<IEnumerable<PostLikesGetResponse>> GetPostLikes(PostLikesGetRequest request);
        Task<PostLikesDeleteResponse> DeletePostLike(PostLikesDeleteRequest request);
        Task<PostLikesDeleteResponse> DeleteAllPostLikes(int id);
        #endregion
    }
}
