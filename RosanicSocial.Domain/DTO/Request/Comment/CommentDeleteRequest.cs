using RosanicSocial.Domain.Data.Entities.Post;
using System;
using System.Collections.Generic;

namespace RosanicSocial.Domain.DTO.Request.Comment {
    public class CommentDeleteRequest {
        public int CommentId { get; set; }
        
        public CommentEntity ToEntity() {
            return new CommentEntity {
                Id = CommentId
            };
        }
    }
}
