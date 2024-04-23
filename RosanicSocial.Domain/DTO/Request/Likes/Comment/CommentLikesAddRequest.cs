using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Likes.Comment {
    public class CommentLikesAddRequest {
        public int UserId { get; set; }
        public int CommentId { get; set; }
    }
}
