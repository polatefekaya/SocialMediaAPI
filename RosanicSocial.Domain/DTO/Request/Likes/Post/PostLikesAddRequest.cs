using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Likes.Post {
    public class PostLikesAddRequest {
        public int UserId { get; set; }
        public int PostId { get; set; }

        public PostLikesEntity ToEntity() {
            return new PostLikesEntity {
                UserId = UserId,
                PostId = PostId
            };
        }
    }
}
