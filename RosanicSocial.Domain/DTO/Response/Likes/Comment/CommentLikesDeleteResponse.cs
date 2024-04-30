using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Likes.Comment {
    public class CommentLikesDeleteResponse {
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class CommentLikesEntityExtensions {
        public static CommentLikesDeleteResponse ToDeleteResponse (this CommentLikesEntity entity) {
            return new CommentLikesDeleteResponse {
                UserId = entity.UserId,
                CommentId = entity.CommentId,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
