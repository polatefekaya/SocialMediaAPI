using RosanicSocial.Domain.DTO.Request.Seen.Post;
using RosanicSocial.Domain.DTO.Response.Seen.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IPostSeenDbService {
        Task<PostSeenAddResponse> AddPostSeen(PostSeenAddRequest request);
        Task<PostSeenDeleteResponse> DeletePostSeen(PostSeenDeleteRequest request);
        Task<PostSeenGetResponse[]> GetAllPostSeensByUserId(PostSeenGetAllByUserIdRequest request);
        Task<PostSeenGetResponse[]> GetAllPostSeensByPostId(PostSeenGetAllByPostIdRequest request);
        Task<PostSeenDeleteResponse[]> DeleteAllPostSeensByPostId(PostSeenDeleteAllByPostIdRequest request);
        Task<PostSeenDeleteResponse[]> DeleteAllPostSeensByUserId(PostSeenDeleteAllByUserIdRequest request);

    }
}
