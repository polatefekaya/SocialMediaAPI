using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Comment {
    public class CommentUpdateRequest {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int? RepliedUserId { get; set; }
        public string? Body { get; set; }
        public bool IsUpdated { get; set; } = false;
        public bool IsReply { get; set; } = false;
        public CommentEntity ToEntity() {
            return new CommentEntity {
                Id = Id,
                PostId = PostId,
                UserId = UserId,
                RepliedUserId = Id,
                Body = Body,
                IsUpdated = IsUpdated,
                IsReply = IsReply 
            };
        }
    }
}
