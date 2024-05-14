using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Comment {
    public class CommentUpdateCommentCountRequest {
        public int CommentId { get; set; }
        public int Change { get; set; }
    }
}
