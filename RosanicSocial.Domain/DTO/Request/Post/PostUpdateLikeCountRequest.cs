using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Post {
    public class PostUpdateLikeCountRequest {
        public int PostId { get; set; }
        public int Change { get; set; }
    }
}
