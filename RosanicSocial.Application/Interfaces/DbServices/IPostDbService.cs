using System;
using System.Collections.Generic;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Response.Post;

namespace RosanicSocial.Application.Interfaces.DbServices {
    /// <summary>
    /// CRUD operations for Like Entity.
    /// <para>
    /// Functionality:
    /// </para>
    /// <list type="bullet">
    /// <item>Add</item>
    /// <item>Get</item>
    /// <item>GetFollowingUsersPosts</item>
    /// <item>GetInterestedPosts</item>
    /// <item>GetAll</item>
    /// <item>GetByCategory</item>
    /// <item>GetByType</item>
    /// <item>GetByTopic</item>
    /// <item>Update</item>
    /// <item>Delete</item>
    /// <item>DeleteBatch</item>
    /// <item>DeleteAll</item>
    /// </list>
    /// This DbService calls Repository interfaces for it's db processes
    /// </summary>
    public interface IPostDbService
    {
        Task<PostAddResponse> AddPost(PostAddRequest request);
        Task<PostGetResponse> GetPost(PostGetRequest request);
        Task<PostGetFollowingsResponse> GetFollowingUsersPosts(PostGetFollowingsRequest request);
        Task<PostGetInterestedResponse> GetInterestedPosts(PostGetInterestedRequest request);
        Task<PostGetAllResponse> GetAllPosts(PostGetAllRequest request);
        Task<PostGetByCategoryResponse> GetByCategoryPost(PostGetByCategoryRequest request);
        Task<PostGetByTypeResponse> GetByTypePost(PostGetByTypeRequest request);
        Task<PostGetByTopicResponse> GetByTopicPost(PostGetByTopicRequest request);
        Task<PostUpdateResponse> UpdatePost(PostUpdateRequest request);
        Task<PostDeleteResponse> DeletePost(PostDeleteRequest request);
        Task<PostDeleteBatchResponse> DeleteBatchPost(PostDeleteBatchRequest request);
        Task<PostDeleteAllResponse> DeleteAllPosts(PostDeleteAllRequest request);
    }
}
