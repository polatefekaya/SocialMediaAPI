using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Seen.Post {
    public class PostSeenAddResponse {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class PostSeenEntityExtensions {
        public static PostSeenAddResponse ToAddResponse (this PostSeenEntity entity) {
            return new PostSeenAddResponse {
                UserId = entity.UserId,
                PostId = entity.PostId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
