using RosanicSocial.Domain.Data.Entities.Post;
using RosanicSocial.Domain.DTO.Request.Comment;
using RosanicSocial.Domain.DTO.Response.Comment;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    /// <summary>
    /// CRUD operations for Comment Entity.
    /// <list type="bullet">
    /// <item>Add</item>
    /// <item>Get</item>
    /// <item>GetAll</item>
    /// <item>Update</item>
    /// <item>Delete</item>
    /// </list>
    /// This DbService calls Repository interfaces for it's db processes
    /// </summary>
    public interface ICommentDbService {
        /// <summary>
        /// Adds given comment entity to database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommentAddResponse> AddCommentAsync(CommentAddRequest request);
        /// <summary>
        /// Gets the comment from database by it's <paramref name="id"/> and returns it.
        /// <paramref name="id"/> is must given with <paramref name="request"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommentGetResponse> GetCommentAsync(CommentGetRequest request);
        /// <summary>
        /// Gets all the comments for user from database by users <paramref name="id"/> and returns it.
        /// <paramref name="id"/> is must given with <paramref name="request"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommentGetAllByUserIdResponse> GetAllCommentsByUserIdAsync(CommentGetAllByUserIdRequest request);
        /// <summary>
        /// Gets all the comments for user from database by users <paramref name="id"/> and returns it.
        /// <paramref name="id"/> is must given with <paramref name="request"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommentGetAllByPostIdResponse> GetAllCommentsByPostIdAsync(CommentGetAllByPostIdRequest request);
        /// <summary>
        /// Updates the comment from database by it's <paramref name="id"/> and returns it.
        /// <para>Updates all the comment information whether it's given or not.</para>
        /// <paramref name="id"/> is must given with <paramref name="request"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommentUpdateResponse> UpdateCommentAsync(CommentUpdateRequest request);
        /// <summary>
        /// Deletes the comment from database by users <paramref name="id"/> and returns it.
        /// <paramref name="id"/> is must given with <paramref name="request"/>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CommentDeleteResponse> DeleteCommentAsync(CommentDeleteRequest request);
    }
}
