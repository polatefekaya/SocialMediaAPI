using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RosanicSocial.Domain.Data.Entites.Post
{
    public class PostLikesEntity
    {
        [Key]
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
