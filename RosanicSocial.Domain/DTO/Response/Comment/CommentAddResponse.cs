using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Comment {
    public class CommentAddResponse {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int RepliedUserId { get; set; }
        public string Body { get; set; } = string.Empty;
        public bool IsUpdated { get; set; }
        public bool IsReply { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public static partial class CommentEntityExtensions
    {
        public static CommentAddResponse ToAddResponse(this CommentEntity entity) {
            return new CommentAddResponse {
                Id = entity.Id,
                PostId = entity.PostId,
                UserId = entity.UserId,
                RepliedUserId = entity.RepliedUserId,
                Body = entity.Body,
                IsUpdated = entity.IsUpdated,
                IsReply = entity.IsReply,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
