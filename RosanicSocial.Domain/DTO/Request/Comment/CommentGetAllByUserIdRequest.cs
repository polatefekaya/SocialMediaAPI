using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Comment {
    public class CommentGetAllByUserIdRequest {
        public int UserId { get; set; }
    }
}
