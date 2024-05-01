using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Seen.Post {
    public class PostSeenGetResponse {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class PostSeenEntityExtensions {
        public static PostSeenGetResponse ToGetResponse(this PostSeenEntity entity) {
            return new PostSeenGetResponse {
                UserId = entity.UserId,
                PostId = entity.PostId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
