using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Comment {
    public class CommentUpdateResponse {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int? RepliedUserId { get; set; }
        public string? Body { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsReply { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class CommentEntityExtensions {
        public static CommentUpdateResponse ToUpdateResponse (this CommentEntity entity) {
            return new CommentUpdateResponse {
                Id = entity.Id,
                PostId = entity.PostId,
                UserId = entity.UserId,
                RepliedUserId = entity.RepliedUserId,
                Body = entity.Body,
                IsUpdated = entity.IsUpdated,
                IsReply = entity.IsReply,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
