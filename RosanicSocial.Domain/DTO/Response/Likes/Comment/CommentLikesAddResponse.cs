using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Likes.Comment {
    public class CommentLikesAddResponse {
        public int UserId { get; set; }
        public int CommentId { get; set; }
    }
    public static partial class CommentLikesEntityExtensions {
        public static CommentLikesAddResponse ToAddResponse(this CommentLikesEntity entity) {
            return new CommentLikesAddResponse {
                UserId = entity.UserId,
                CommentId = entity.CommentId
            };
        }
    }
}
