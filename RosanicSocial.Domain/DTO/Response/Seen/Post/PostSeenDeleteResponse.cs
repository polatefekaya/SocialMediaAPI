using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Seen.Post {
    public class PostSeenDeleteResponse {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class PostSeenEntityExtensions {
        public static PostSeenDeleteResponse ToDeleteResponse(this PostSeenEntity entity) {
            return new PostSeenDeleteResponse {
                UserId = entity.UserId,
                PostId = entity.PostId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
