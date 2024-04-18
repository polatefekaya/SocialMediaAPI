using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entites.Post {
    public class CommentEntity {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int RepliedUserId { get; set; }
        public string Body { get; set; } = string.Empty;
        public bool IsUpdated { get; set; }
        public bool IsReply { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
