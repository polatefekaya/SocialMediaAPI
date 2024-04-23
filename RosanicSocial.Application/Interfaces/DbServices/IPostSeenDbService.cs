using RosanicSocial.Domain.DTO.Request.Seen.Post;
using RosanicSocial.Domain.DTO.Response.Seen.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Interfaces.DbServices {
    public interface IPostSeenDbService {
        Task<PostSeenAddResponse> AddPostSeen(PostSeenAddRequest request);
        Task<PostSeenDeleteResponse> DeletePostSeen(PostSeenDeleteRequest request);
        Task<PostSeenGetAllByUserIdResponse> GetAllPostSeensByUserId(PostSeenGetAllByUserIdRequest request);
        Task<PostSeenGetAllByPostIdResponse> GetAllPostSeensByPostId(PostSeenGetAllByPostIdRequest request);
        Task<PostSeenDeleteAllByPostIdResponse> DeleteAllPostSeensByPostId(PostSeenDeleteAllByPostIdRequest request);
        Task<PostSeenDeleteAllByUserIdResponse> DeleteAllPostSeensByUserId(PostSeenDeleteAllByUserIdRequest request);

    }
}
