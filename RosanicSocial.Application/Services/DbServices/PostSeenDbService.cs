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

        public Task<PostSeenDeleteAllByPostIdResponse> DeleteAllPostSeensByPostId(PostSeenDeleteAllByPostIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostSeenDeleteAllByUserIdResponse> DeleteAllPostSeensByUserId(PostSeenDeleteAllByUserIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostSeenDeleteResponse> DeletePostSeen(PostSeenDeleteRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostSeenGetAllByPostIdResponse> GetAllPostSeensByPostId(PostSeenGetAllByPostIdRequest request) {
            throw new NotImplementedException();
        }

        public Task<PostSeenGetAllByUserIdResponse> GetAllPostSeensByUserId(PostSeenGetAllByUserIdRequest request) {
            throw new NotImplementedException();
        }
    }
}
