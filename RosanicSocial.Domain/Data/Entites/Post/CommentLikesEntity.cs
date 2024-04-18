using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entites.Post
{
    public class CommentLikesEntity
    {
        [Key]
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
