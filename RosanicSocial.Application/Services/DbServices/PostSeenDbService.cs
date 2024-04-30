using RosanicSocial.Application.Interfaces.DbServices;
using RosanicSocial.Domain.DTO.Request.Seen.Post;
using RosanicSocial.Domain.DTO.Response.Seen.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Application.Services.DbServices {
    public class PostSeenDbService : IPostSeenDbService {
        public Task<PostSeenAddResponse> AddPostSeen(PostSeenAddRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostSeenDeleteResponse[]> DeleteAllPostSeensByPostId(PostSeenDeleteAllByPostIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostSeenDeleteResponse[]> DeleteAllPostSeensByUserId(PostSeenDeleteAllByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostSeenDeleteResponse> DeletePostSeen(PostSeenDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostSeenGetResponse[]> GetAllPostSeensByPostId(PostSeenGetAllByPostIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostSeenGetResponse[]> GetAllPostSeensByUserId(PostSeenGetAllByUserIdRequest request) {
            throw new NotImplementedException();
        }
    }
}
