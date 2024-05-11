using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Likes.Post {
    public class PostLikesGetAllByUserIdRequest {
        public int UserId { get; set; }
        public int? Limit { get; set; }
    }
}
