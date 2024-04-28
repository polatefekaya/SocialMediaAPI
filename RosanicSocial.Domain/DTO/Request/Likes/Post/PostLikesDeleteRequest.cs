using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Likes.Post 
{
    public class PostLikesDeleteRequest {
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
