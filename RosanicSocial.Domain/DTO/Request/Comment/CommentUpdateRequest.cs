using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.DTO.Request.Comment {
    public class CommentUpdateRequest {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int? RepliedUserId { get; set; }
        public string? Body { get; set; } = string.Empty;
        public bool? IsUpdated { get; set; }
        public bool? IsReply { get; set; }
    }
}
