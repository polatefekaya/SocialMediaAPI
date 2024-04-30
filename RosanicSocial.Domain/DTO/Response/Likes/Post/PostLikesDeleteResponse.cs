using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Likes.Post {
    public class PostLikesDeleteResponse {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class PostLikesEntityExtensions {
        public static PostLikesDeleteResponse ToDeleteResponse(this PostLikesEntity entity) {
            return new PostLikesDeleteResponse {
                UserId = entity.UserId,
                PostId = entity.PostId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
