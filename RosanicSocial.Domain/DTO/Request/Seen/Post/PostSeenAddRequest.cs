using RosanicSocial.Domain.Data.Entities.Statistic;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Seen.Post {
    public class PostSeenAddRequest {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public PostSeenEntity ToEntity() {
            return new PostSeenEntity {
                UserId = UserId,
                PostId = PostId
            };
        }
    }
}
