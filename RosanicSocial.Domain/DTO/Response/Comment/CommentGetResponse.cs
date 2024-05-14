using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Response.Comment {
    public class CommentGetResponse {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int? RepliedUserId { get; set; }
        public int LikeCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public int Dimension { get; set; } = 0;
        public string? Body { get; set; }
        public bool IsUpdated { get; set; } = false;
        public bool IsReply { get; set; } = false;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
    public static partial class CommentEntityExtensions{
        public static CommentGetResponse ToGetResponse(this CommentEntity entity) {
            return new CommentGetResponse {
                Id = entity.Id,
                PostId = entity.PostId,
                UserId = entity.UserId,
                RepliedUserId = entity.RepliedUserId,
                LikeCount = entity.LikeCount,
                CommentCount = entity.CommentCount,
                Dimension = entity.Dimension,
                Body = entity.Body,
                IsUpdated = entity.IsUpdated,
                IsReply = entity.IsReply,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}
