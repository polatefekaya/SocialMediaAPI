using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entities.Post
{
    public class CommentLikesEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
