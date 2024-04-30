using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Likes.Post {
    public class PostLikesAddResponse {
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
    public static partial class PostLikesEntityExtensions {
        public static PostLikesAddResponse ToAddResponse(this PostLikesEntity entity) {
            return new PostLikesAddResponse {
                UserId = entity.UserId,
                PostId = entity.PostId
            };
        }
    }
}
