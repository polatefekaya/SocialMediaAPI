using System;
using System.Collections.Generic;
using RosanicSocial.Domain.DTO.Request.Post;
using RosanicSocial.Domain.DTO.Request.Rose;
using RosanicSocial.Domain.DTO.Response.Post;
using RosanicSocial.Domain.DTO.Response.Rose;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IPostDbService
    {
        Task<PostAddResponse> AddPost(PostAddRequest request);
        Task<PostGetResponse> GetPost(PostGetRequest request);
        Task<PostGetAllResponse> GetAllPosts(PostGetAllRequest request);
        Task<PostGetByCategoryResponse> GetByCategoryPost(PostGetByCategoryRequest request);
        Task<PostGetByTypeResponse> GetByTypePost(PostGetByTypeRequest request);
        Task<PostGetByTopicResponse> GetByTopicPost(PostGetByTopicRequest request);
        Task<PostUpdateResponse> UpdatePost(PostUpdateRequest request);
        Task<PostDeleteResponse> DeletePost(PostDeleteRequest request);
        Task<PostDeleteBatchResponse> DeleteBatchPost(PostDeleteBatchRequest request);
    }
}
