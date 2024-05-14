using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Post {
    public class PostUpdateCommentCountRequest {
        public int PostId { get; set; }
        public int Change { get; set; }
    }
}
