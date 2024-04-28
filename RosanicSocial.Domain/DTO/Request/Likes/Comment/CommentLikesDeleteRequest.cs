using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Likes.Comment {
    public class CommentLikesDeleteRequest {
        public int UserId { get; set; }
        public int CommentId { get; set; }
    }
}
