using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Likes.Comment {
    public class CommentLikesUpdateRequest {
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public CommentLikesEntity ToEntity() {
            return new CommentLikesEntity {
                UserId = UserId,
                CommentId = CommentId
            };
        }
    }
}
