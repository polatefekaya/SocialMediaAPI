using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Likes.Post {
    public class PostLikesByUserIdGetRequest {
        public int UserId { get; set; }
        public int? Limit { get; set; }
    }
}
