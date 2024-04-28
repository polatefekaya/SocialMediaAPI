using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Comment {
    public class CommentUpdateRequest {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int? RepliedUserId { get; set; }
        public string? Body { get; set; }
        public bool IsUpdated { get; set; } = false;
        public bool IsReply { get; set; } = false;
        public CommentEntity ToEntity() {
            return new CommentEntity {
                PostId = PostId,
                UserId = UserId,
                RepliedUserId = RepliedUserId,
                Body = Body,
                IsUpdated = IsUpdated,
                IsReply = IsReply 
            };
        }
    }
}
