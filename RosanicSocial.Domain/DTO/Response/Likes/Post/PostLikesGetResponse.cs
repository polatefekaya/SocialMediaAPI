using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Likes.Post {
    public class PostLikesGetResponse {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class PostLikesEntityExtensions {
        public static PostLikesGetResponse ToGetResponse (this PostLikesEntity entity) {
            return new PostLikesGetResponse {
                UserId = entity.UserId,
                PostId = entity.PostId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
