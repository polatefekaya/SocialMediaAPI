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
    /// <item>GetByUserId</item>
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
    /// <item>GetByUserId</item>
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
        Task<CommentLikesAddResponse?> AddCommentLike(CommentLikesAddRequest request);
        /// <summary>
        /// Gets the Likes Entities for given <paramref name="commentId"/> by comments from database.
        /// <para>
        /// It needs to know which comment to get Likes Entities. 
        /// </para>
        /// <para>
        /// Giving <paramref name="commentId"/> in <paramref name="request"/> is a must.
        /// </para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Likes Entities by Comment's likes</returns>
        Task<CommentLikesGetResponse[]> GetAllCommentLikesByCommentId(CommentLikesGetAllByCommentIdRequest request);
        /// <summary>
        /// Gets the Likes Entities for given <paramref name="userId"/> by comments from database.
        /// <para>
        /// It needs to know which user to get Likes Entities. 
        /// </para>
        /// <para>
        /// Giving <paramref name="userId"/> in <paramref name="request"/> is a must.
        /// </para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Likes Entities by User's liked comments</returns>
        Task<CommentLikesGetResponse[]> GetAllCommentLikesByUserId(CommentLikesGetAllByUserIdRequest request);
        /// <summary>
        /// Gets the Likes Entities for given <paramref name="userId"/> by comments from database.
        /// <para>
        /// It needs to know which user to get Likes Entities. 
        /// </para>
        /// <para>
        /// Giving <paramref name="userId"/> in <paramref name="request"/> is a must.
        /// </para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Likes Entities by User's liked comments</returns>
        Task<CommentLikesGetResponse?> GetCommentLike(CommentLikesGetRequest request);
        /// <summary>
        /// Deletes the Likes Entity from database.
        /// <para>
        /// It needs to know which comment entity to delete like data. 
        /// </para>
        /// <para>
        /// Giving <paramref name="commentId"/> in <paramref name="request"/> is a must.
        /// </para>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommentLikesDeleteResponse?> DeleteCommentLike(CommentLikesDeleteRequest request);
        Task<CommentLikesDeleteResponse[]> DeleteAllCommentLikesByUserId(CommentLikesDeleteAllByUserIdRequest request);
        Task<CommentLikesDeleteResponse[]> DeleteAllCommentLikesCommentId(CommentLikesDeleteAllByCommentIdRequest request);
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
        Task<PostLikesAddResponse?> AddPostLike(PostLikesAddRequest request);
        Task<PostLikesGetResponse[]> GetAllPostLikesByPostId(PostLikesGetAllByPostIdRequest request);
        Task<PostLikesGetResponse[]> GetAllPostLikesByUserId(PostLikesGetAllByUserIdRequest request);
        Task<PostLikesGetResponse?> GetPostLike(PostLikesGetRequest request);
        Task<PostLikesDeleteResponse?> DeletePostLike(PostLikesDeleteRequest request);
        Task<PostLikesDeleteResponse[]> DeleteAllPostLikesByUserId(PostLikesDeleteAllByUserIdRequest request);
        Task<PostLikesDeleteResponse[]> DeleteAllPostLikesByPostId(PostLikesDeleteAllByPostIdRequest request);
        #endregion
    }
}
