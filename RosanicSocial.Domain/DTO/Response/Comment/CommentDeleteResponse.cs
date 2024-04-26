using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Comment {
    public class CommentDeleteResponse {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int? RepliedUserId { get; set; }
    }
    public static partial class CommentEntityExtensions {
        public static CommentDeleteResponse ToDeleteResponse(this CommentEntity entity) {
            return new CommentDeleteResponse {
                Id = entity.Id,
                PostId = entity.PostId,
                UserId = entity.UserId,
                RepliedUserId = entity.RepliedUserId
            };
        }
    }
}
