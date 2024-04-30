using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Seen.Post {
    public class PostSeenDeleteRequest {
        public int UserId { get; set; }
        public int PostId { get; set; } 
    }
}
